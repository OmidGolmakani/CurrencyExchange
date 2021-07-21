﻿using AutoMapper;
using CurrencyExchange.Controllers;
using CurrencyExchange.CustomException;
using CurrencyExchange.Data;
using CurrencyExchange.Models.Dto.ApplicationUsers;
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
            return Ok(_account.GetAll().Result.ToList());
        }
        [HttpGet("GetByAuthStatus")]
        public async Task<IActionResult> GetByAuthStatus(Models.Enum.AuthUserItem.Status status)
        {
            var Result = await _account.GetAccountByAuthStatus(status);
            return Ok(Result.ToList());
        }
        [HttpPost("Register")]
        [AllowAnonymous]
        public async Task<IActionResult> AddUserWithPhone(RegisterWithPhoneDto RegisterInfo)
        {
            try
            {
                var Register = await _account.AddUserWithPhone(RegisterInfo);
                var Login = await _account.SignIn(Register);
                return Ok(Login);
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
        [HttpPost("VerifyPhoneNumber")]
        public async Task<IActionResult> VerifyPhoneNumber(string UserId, string Token)
        {
            try
            {
                var Result = await _account.VerifyPhoneNumber(UserId, Token);
                if (Result.Errors.Count() != 0)
                {
                    return new ObjectResult(Result.Errors);
                }
                return Ok(Result);
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
    }
}
