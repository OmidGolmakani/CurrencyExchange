using AutoMapper;
using CurrencyExchange.Areas.Membership.Interfaces;
using CurrencyExchange.CustomException;
using CurrencyExchange.Data;
using CurrencyExchange.Models.Dto.ApplicationUsers;
using CurrencyExchange.Models.Entity;
using CurrencyExchange.Models.Repository.Interfaces;
using CurrencyExchange.Models.Validation;
using FluentValidation;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyExchange.Models.Repository.Services
{
    public abstract class Account : IAccount
    {
        protected Account(UserManager<ApplicationUser> UserManager,
                          IMapper mapper,
                          ApplicationDbContext dbContext)
        {
            this._UserManager = UserManager;
            this._mapper = mapper;
            this._dbContext = dbContext;
        }
        private readonly UserManager<ApplicationUser> _UserManager;
        private readonly IMapper _mapper;
        private readonly ApplicationDbContext _dbContext;

        public ValueTask<EntityEntry<ApplicationUserDto>> Add(ApplicationUserDto entity)
        {
            throw new NotImplementedException();
        }

        public Task AddRange(IEnumerable<ApplicationUserDto> entities)
        {
            throw new NotImplementedException();
        }

        public Task<ApplicationUserDto> AddUser(ApplicationUserDto user, string password)
        {
            try
            {
                var _user = _mapper.Map<ApplicationUser>(user);
                _user.PasswordHash = _UserManager.PasswordHasher.HashPassword(_user, password);
                ApplicationUserValidator validator = new ApplicationUserValidator(_dbContext, _UserManager);
                validator.ValidateAndThrow(_user);
                Task<IdentityResult> UserTask;
                //PasswordValidation(Password);
                UserTask = _UserManager.CreateAsync(_user);
                if (UserTask.Result.Errors.Count() != 0)
                {
                    throw new Exception(UserTask.Result.Errors.First().Description);
                }
                UserTask.Wait();
                if (UserTask.Result.Succeeded)
                {
                    _user = _UserManager.FindByIdAsync(_user.Id.ToString()).Result;
                }
                return Task.FromResult(_mapper.Map<ApplicationUserDto>(_user));
            }
            catch (MyException ex)
            {

                throw ex;
            }
        }

        public Task<PhoneNumberTokenResultDto> ChangePhoneNumberToken(string UserId, string PhoneNumber)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ApplicationUserDto>> Find(Expression<Func<ApplicationUserDto, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ApplicationUserDto>> GetAll()
        {
            throw new NotImplementedException();
        }

        public ValueTask<ApplicationUserDto> GetById(object Id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> GetChangeEmailToken(string UserId, string newEmail)
        {
            throw new NotImplementedException();
        }

        public void Remove(ApplicationUserDto entity)
        {
            throw new NotImplementedException();
        }

        public void RemoveRange(IEnumerable<ApplicationUserDto> entities)
        {
            throw new NotImplementedException();
        }

        public Task<IdentityResult> ResetPassword(string UserInfo)
        {
            throw new NotImplementedException();
        }

        public Task<bool> SendEmailToken(long UserId)
        {
            throw new NotImplementedException();
        }

        public Task<PhoneNumberTokenResultDto> SendPhoneNumberToken(long UserId, string Token, string newPassword)
        {
            throw new NotImplementedException();
        }

        public Task<string> SendResetPasswordToken(string UserInfo)
        {
            throw new NotImplementedException();
        }

        public Task<string> SendVerifyChangeEmail(string UserId, string newEmail, string Token)
        {
            throw new NotImplementedException();
        }

        public Task<string> SendVerifyEmail(string UserId, string Token)
        {
            throw new NotImplementedException();
        }

        public Task<SignInResultDto> SignIn(ApplicationUserLogin login)
        {
            throw new NotImplementedException();
        }

        public Task SignOut()
        {
            throw new NotImplementedException();
        }

        public EntityEntry<ApplicationUserDto> Update(ApplicationUserDto entity)
        {
            throw new NotImplementedException();
        }

        public void UpdateRange(IEnumerable<ApplicationUserDto> entities)
        {
            throw new NotImplementedException();
        }

        public Task<bool> VerifyChangeEmail(string UserId, string Token)
        {
            throw new NotImplementedException();
        }

        public Task<bool> VerifyEmail(string UserId, string Token)
        {
            throw new NotImplementedException();
        }

        public Task<IdentityResult> VerifyPhoneNumber(string UserId, string Token)
        {
            throw new NotImplementedException();
        }
    }
}
