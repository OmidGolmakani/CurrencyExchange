using AutoMapper;
using CurrencyExchange.Areas.Membership.Interfaces;
using CurrencyExchange.CustomException;
using CurrencyExchange.Data;
using CurrencyExchange.Helpers;
using CurrencyExchange.Models.Dto.ApplicationUsers;
using CurrencyExchange.Models.Entity;
using CurrencyExchange.Models.Helper;
using CurrencyExchange.Models.Repository.Interfaces;
using CurrencyExchange.Models.Validation;
using CurrencyExchange.OtherServices.SMS.Services;
using CurrencyExchange.OtherServices.SMS.Services.MeliPayamak;
using FluentValidation;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CurrencyExchange.Models.Repository.Services
{
    public class Account : IAccount<long>
    {
        private IEnumerable<ApplicationUser> GetAccounts() => _dbContext.Users;
        private IEnumerable<ApplicationUserRole> GetApplicationUserRoles() => _dbContext.UserRoles;
        private IEnumerable<ApplicationRole> GetRoles() => _dbContext.Roles;
        private IEnumerable<Entity.AuthUserItem> GetAuthUserItems() => _dbContext.AuthUserItems;
        private IEnumerable<Entity.BankAccount> GetBankAccounts() => _dbContext.BankAccounts;
        public Account(UserManager<ApplicationUser> userManager,
                       SignInManager<ApplicationUser> signInManager,
                       IAuthUserItem authUserItemSrv,
                       SendMessageService smsSvr,
                       IMapper mapper,
                       ApplicationDbContext dbContext)
        {
            this._userManager = userManager;
            this._mapper = mapper;
            this._dbContext = dbContext;
            this._signInManager = signInManager;
            this._authUserItemSrv = authUserItemSrv;
            this.smsSvr = smsSvr;
        }
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMapper _mapper;
        private readonly ApplicationDbContext _dbContext;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IAuthUserItem _authUserItemSrv;
        private readonly SendMessageService smsSvr;

        public Task<EntityEntry<ApplicationUserDto>> Add(ApplicationUserDto entity)
        {
            throw new NotImplementedException();

        }
        public Task AddRange(IEnumerable<ApplicationUserDto> entities)
        {
            throw new NotImplementedException();
        }

        public Task<long> AddUserWithPhone(RegisterWithPhoneDto RegisterInfo)
        {
            try
            {
                var _user = _mapper.Map<ApplicationUser>(RegisterInfo);
                _user.PasswordHash = _userManager.PasswordHasher.HashPassword(_user, RegisterInfo.Password);
                _user.UserName = RegisterInfo.PhoneNumber;
                //_user.PhoneNumberConfirmed = true;
                ApplicationUserValidator validator = new ApplicationUserValidator(_dbContext, _userManager);
                validator.ValidateAndThrow(_user);
                Task<IdentityResult> UserTask;
                //PasswordValidation(RegisterInfo.Password);
                UserTask = _userManager.CreateAsync(_user);
                if (UserTask.Result.Errors.Count() != 0)
                {
                    throw new MyException(UserTask.Result.Errors.First().Description);
                }
                UserTask.Wait();
                if (UserTask.Result.Succeeded)
                {
                    _user = _userManager.FindByIdAsync(_user.Id.ToString()).Result;
                    var UserRoleTask = _userManager.AddToRoleAsync(_user, "User");
                    UserRoleTask.Wait();
                    var PhoneNumberToken = _userManager.GenerateChangePhoneNumberTokenAsync(_user, _user.PhoneNumber);
                    PhoneNumberToken.Wait();
                    //smsSvr.SendMessage(_user.PhoneNumber, "");
                }
                return Task.FromResult(_user.Id);
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

            return Task.FromResult(ApplicationUserFunc.MapApplicationUser(GetAccounts(),
                                                                          GetApplicationUserRoles(),
                                                                          GetRoles(),
                                                                          GetAuthUserItems(),
                                                                          GetBankAccounts()));
        }

        public Task<ApplicationUserDto> GetById(long Id)
        {
            var Result = ApplicationUserFunc.MapApplicationUser(GetAccounts(),
                                                                GetApplicationUserRoles(),
                                                                GetRoles(),
                                                                GetAuthUserItems(),
                                                                GetBankAccounts()
                                                                ).FirstOrDefault(x => x.Id == Id);
            return Task.FromResult(Result);
        }

        public Task<bool> GetChangeEmailToken(string UserId, string newEmail)
        {
            throw new NotImplementedException();
        }

        public void Remove(long Id)
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

        public Task<SignInResultDto> SignIn(CUserLoginDto login)
        {
            try
            {
                var _user = _userManager.FindByNameAsync(login.UserName);
                Tuple<string, double> tokenInfo = null;
                SignInResultDto Result = null;
                _user.Wait();
                if (_user.Result == null || _user.Result.Id == 0)
                {
                    return Task.FromResult(new SignInResultDto() { SignIn = SignInResult.Failed });
                }
                else
                {
                    var SigninResult = _signInManager.PasswordSignInAsync(login.UserName, login.Password, false, false);
                    SigninResult.Wait();
                    if (SigninResult.Result.Succeeded)
                    {
                        tokenInfo = Helpers.JWTTokenManager.GenerateToken(login.UserName, _dbContext);
                        var authStatus = _authUserItemSrv.GetAuthUserStatus(_user.Result.Id).Result;
                        Result = new SignInResultDto()
                        {
                            SignIn = SigninResult.Result,
                            UserId = _user.Result.Id,
                            Token = tokenInfo.Item1,
                            ExprireDate = tokenInfo.Item2,
                            IsAdmin = _userManager.GetRolesAsync(_user.Result).Result.Count(x => x == "Administrator") == 0 ? false : true,
                            AuthUserStatusId = authStatus.StatusId
                        };
                    }
                    else
                    {
                        Result = new SignInResultDto()
                        {
                            UserId = _user.Result.Id,
                            SignIn = SigninResult.Result
                        };
                    }
                }
                return Task.FromResult(Result);
            }
            catch (MyException ex)
            {
                throw ex;
            }
        }

        public Task SignOut()
        {
            try
            {
                var Result = _signInManager.SignOutAsync();
                return Result;
            }
            catch (MyException ex)
            {
                throw ex;
            }
        }

        public void Update(ApplicationUserDto entity)
        {
            ApplicationUser _entity = _dbContext.Users.Find(entity.Id);
            _mapper.Map<ApplicationUserDto, ApplicationUser>(entity, _entity);
            var Result = _dbContext.Users.Update(_entity);
        }

        public void UpdateRange(IEnumerable<ApplicationUserDto> entities)
        {
            throw new NotImplementedException();
        }

        public Task<bool> VerifyChangeEmail(string UserId, string Token)
        {
            throw new NotImplementedException();
        }

        public Task<IdentityResult> VerifyEmail(string UserId, string Token)
        {
            try
            {
                Task<ApplicationUser> _user = _userManager.FindByIdAsync(UserId);
                if (_user.Result == null)
                {
                    throw GetAccountExceptions(ErrorMessageType.UserNotFound);
                }
                Task<IdentityResult> ComfirmResult = null;
                ComfirmResult = _userManager.ConfirmEmailAsync(_user.Result, Token);
                ComfirmResult.Wait();
                return ComfirmResult;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Task<IdentityResult> VerifyPhoneNumber(string UserId, string Token, string PhoneNumber = "")
        {
            try
            {
                Task<ApplicationUser> _user = _userManager.FindByIdAsync(UserId);
                if (_user.Result == null)
                {
                    throw GetAccountExceptions(ErrorMessageType.UserNotFound);
                }
                Task<IdentityResult> ComfirmResult = null;
                if (PhoneNumber == "") PhoneNumber = _user.Result.PhoneNumber;
                ComfirmResult = _userManager.ChangePhoneNumberAsync(_user.Result, PhoneNumber, Token);
                ComfirmResult.Wait();
                return ComfirmResult;
            }
            catch (MyException ex)
            {
                throw ex;
            }
        }
        public Task<string> ResetPasswordToken(string UserInfo)
        {
            try
            {
                var user = _userManager.Users.FirstOrDefaultAsync(x => x.UserName == UserInfo ||
                                                                  x.Email == UserInfo ||
                                                                  x.PhoneNumber == UserInfo);
                if (user.Result == null)
                {
                    throw GetAccountExceptions(ErrorMessageType.UserNotFound);
                }
                return _userManager.GeneratePasswordResetTokenAsync(user.Result);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        internal Task<IdentityResult> ChangeEmailVerify(string UserId, string newEmail, string Token)
        {
            try
            {
                Task<ApplicationUser> _user = _userManager.FindByIdAsync(UserId);
                if (_user.Result == null)
                {
                    throw GetAccountExceptions(ErrorMessageType.UserNotFound);
                }
                Task<IdentityResult> ComfirmResult = null;
                ComfirmResult = _userManager.ChangeEmailAsync(_user.Result, newEmail, Token);
                ComfirmResult.Wait();
                return ComfirmResult;
            }
            catch (MyException ex)
            {
                throw ex;
            }
        }
        private bool PasswordValidation(string Password)
        {
            try
            {
                List<string> Err = new List<string>();
                Err.Add("طول رمز عبور  باید حداقل 10 کاراکتر باشد");
                Err.Add("در رمز عبور باید از حروف غیر الفبایی مانند @ استفاده نمایید");
                Err.Add("رمز عبور باید حداقل شامل یک عدد باشد");
                Err.Add("رمز عبور باید شامل یک حرف بزرگ باشد");
                Err.Add("رمز عبور باید شامل یک حرف کوچک باشد");
                MyException ex = new MyException(JsonConvert.SerializeObject(string.Join(Environment.NewLine, Err)));
                if (Password.Length == 0)
                {
                    throw ex;
                }
                if (Password.Length < 10) throw new MyException(JsonConvert.SerializeObject("طول رمز عبور  باید حداقل 10 کاراکتر باشد"));
                if (Regex.Match(Password, @"[^a-zA-Z\d\s:]").Success == false) throw new MyException(JsonConvert.SerializeObject("در رمز عبور باید از حروف غیر الفبایی مانند @ استفاده نمایید"));
                if (Regex.Match(Password, @"[\d]").Success == false) throw new MyException(JsonConvert.SerializeObject("رمز عبور باید حداقل شامل یک عدد باشد"));
                if (Password.Any(char.IsUpper) == false) throw new MyException(JsonConvert.SerializeObject("رمز عبور باید شامل یک حرف بزرگ باشد"));
                if (Password.Any(char.IsLower) == false) throw new MyException(JsonConvert.SerializeObject("رمز عبور باید شامل یک حرف کوچک باشد"));
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Get Error Exception Before Database Validation
        /// </summary>
        /// <param name="ErrorType"></param>
        /// <returns></returns>
        private MyException GetAccountExceptions(ErrorMessageType ErrorType)
        {
            try
            {
                switch (ErrorType)
                {
                    case ErrorMessageType.UserNotFound:
                        return new MyException("کاربر مورد نظر یافت نشد");
                    default:
                        return null;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public int SaveChanges()
        {
            return _dbContext.SaveChanges();
        }

        public Task<ApplicationUserDto> FirstOrDefault(IEnumerable<ApplicationUserDto> source)
        {
            return Task.FromResult(source.FirstOrDefault());
        }

        public Task<ApplicationUserDto> FirstOrDefault(IEnumerable<ApplicationUserDto> source, Func<ApplicationUserDto, bool> predicate)
        {
            return Task.FromResult(source.FirstOrDefault(predicate));
        }

        public Task<IEnumerable<ApplicationUserDto>> GetAccountByAuthStatus(Enum.AuthUserItem.Status sttaus)
        {
            var Result = ApplicationUserFunc.MapApplicationUser(GetAccounts(),
                                                                GetApplicationUserRoles(),
                                                                GetRoles(),
                                                                GetAuthUserItems(),
                                                                GetBankAccounts()
                                                                ).Where(x => x.AuthStatusId == (byte)sttaus);
            return Task.FromResult(Result);
        }


        private enum ErrorMessageType { UserNotFound = 1 }
    }
}
