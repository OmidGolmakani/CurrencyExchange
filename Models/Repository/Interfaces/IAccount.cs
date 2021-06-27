using CurrencyExchange.Models.Dto.ApplicationUsers;
using CurrencyExchange.Models.Entity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyExchange.Models.Repository.Interfaces
{
    public interface IAccount : IRepository<ApplicationUserDto>
    {
        public Task<ApplicationUserDto> AddUser(ApplicationUserDto user, string password);
        public Task<SignInResultDto> SignIn(ApplicationUserLogin login);
        public Task SignOut();
        public Task<bool> SendEmailToken(long UserId);
        public Task<bool> GetChangeEmailToken(string UserId, string newEmail);
        public Task<string> SendVerifyEmail(string UserId, string Token);
        public Task<string> SendVerifyChangeEmail(string UserId, string newEmail, string Token);
        public Task<bool> VerifyEmail(string UserId, string Token);
        public Task<bool> VerifyChangeEmail(string UserId, string Token);
        public Task<string> SendResetPasswordToken(string UserInfo);
        public Task<IdentityResult> ResetPassword(string UserInfo);
        public Task<PhoneNumberTokenResultDto> SendPhoneNumberToken(long UserId, string Token, string newPassword);
        public Task<PhoneNumberTokenResultDto> ChangePhoneNumberToken(string UserId, string PhoneNumber);
        public Task<IdentityResult> VerifyPhoneNumber(string UserId, string Token);
    }
}
