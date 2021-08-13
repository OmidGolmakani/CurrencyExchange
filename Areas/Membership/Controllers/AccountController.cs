using AutoMapper;
using CurrencyExchange.Controllers;
using CurrencyExchange.CustomException;
using CurrencyExchange.Data;
using CurrencyExchange.Helpers;
using CurrencyExchange.Models.Dto.ApplicationUsers;
using CurrencyExchange.Models.Entity;
using CurrencyExchange.Models.Repository.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CurrencyExchange.Areas.Membership
{
    public class AccountController : BaseController<AccountController>
    {

        private readonly IMapper _mapper;
        private readonly ILogger<AccountController> _logger;
        private readonly ApplicationDbContext dbContext;
        private readonly Account _account;

        public AccountController(IMapper mapper,
                                 ILogger<AccountController> logger,
                                 ApplicationDbContext DbContext,
                                 Account account)
            : base(mapper, logger, DbContext)
        {
            this._mapper = mapper;
            this._logger = logger;
            this.dbContext = DbContext;
            this._account = account;
        }
        [HttpGet("GetAccounts")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _account.GetAll());
        }
        [HttpGet("GetByAuthStatus")]
        public async Task<IActionResult> GetByAuthStatus(Models.Enum.AuthUserItem.Status status)
        {
            var Result = await _account.GetAccountByAuthStatus(status);
            return Ok(Result);
        }
        [HttpPost("Register")]
        [AllowAnonymous]
        public async Task<IActionResult> AddUserWithPhone(RegisterWithPhoneDto RegisterInfo)
        {
            try
            {
                var Register = await _account.AddUserWithPhone(RegisterInfo);
                return Ok(Register);
            }
            catch (MyException ex)
            {

                throw ex;
            }
        }
        [HttpGet("GetAccount")]
        public async Task<IActionResult> GetById(long Id)
        {
            return Ok(await _account.GetById(Id));
        }
        [AllowAnonymous]
        [HttpPost("VerifyPhoneNumber")]
        public async Task<IActionResult> VerifyPhoneNumber(string UserId, string Password, string Token)
        {
            try
            {

                var Result = await _account.VerifyPhoneNumber(UserId, Token);
                SignInResultDto signInResult = null;
                if (Result.Errors.Count() != 0)
                {
                    return new ObjectResult(new { code = 16, description = "کد ارسال شده نامعتبر می باشد" });
                }
                if (Result.Succeeded)
                {
                    var user = await _account.GetById(UserId.ToLong());
                    signInResult = await _account.SignIn(new CUserLoginDto()
                    {
                        UserName = user.UserName,
                        Password = Password
                    });
                }
                return Ok(Result.Succeeded ? signInResult : false);
            }
            catch (MyException ex)
            {
                throw ex;
            }
        }
        [AllowAnonymous]
        [HttpPost("SignIn")]
        public async Task<IActionResult> SignInUser(CUserLoginDto user)
        {

            try
            {
                var Result = await _account.SignIn(user);
                if (Result.SignIn.Succeeded)
                {
                    return Ok(Result);
                }
                else
                {
                    return Unauthorized(Result);
                }
            }
            catch (MyException ex) { throw ex; }
        }
        [AllowAnonymous]
        [HttpPost("SignOut")]
        public async Task<IActionResult> SignOutUser()
        {
            try
            {
                var Result = _account.SignOut();
                return Ok(await Task.FromResult(Result.IsCompletedSuccessfully));
            }
            catch (MyException ex) { throw ex; }
        }
        [AllowAnonymous]
        [HttpPost("SendResetPasswordToken")]
        public async Task<IActionResult> SendResetPasswordToken(string UserInfo)
        {
            await _account.SendResetPasswordToken(UserInfo);
            return Ok(true);
        }
        [AllowAnonymous]
        [HttpPost("ResetPassword")]
        public async Task<IActionResult> ResetPassword(string UserInfo, string Token, string newPassword)
        {
            var Result = await _account.ResetPassword(UserInfo, Token, newPassword);
            if (Result.Succeeded == false)
            {
                return BadRequest(Result.Errors.FirstOrDefault());
            }
            else
            {
                return Ok(true);
            }
        }
        [HttpPost("VerifyChangeEmail")]
        public async Task<IActionResult> VerifyChangeEmail(string UserId, string newEmail, string Token)
        {
            try
            {
                var Result = await _account.ChangeEmailVerify(UserId, newEmail, Token);
                return Ok(Result.Succeeded);
            }
            catch (MyException ex)
            {
                throw ex;
            }
        }
        [HttpPost("deActiveUser")]
        public async Task<IActionResult> deActiveUser(DeActiveUserDto deActiveUser)
        {
            return Ok(await _account.DeActiveUser(deActiveUser));
        }
    }
}
