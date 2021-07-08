using CurrencyExchange.Data;
using CurrencyExchange.Models.Entity;
using FluentValidation;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CurrencyExchange.Models.Validation
{
    public class ApplicationUserValidator : AbstractValidator<ApplicationUser>
    {
        private readonly ApplicationDbContext context;
        private readonly UserManager<ApplicationUser> _userManager;
        public ApplicationUserValidator(ApplicationDbContext dbContext,
                                        UserManager<ApplicationUser> userManager)
        {
            context = dbContext;
            _userManager = userManager;
            RuleFor(x => x.Id).NotNull();
            RuleFor(x => x.UserName).NotNull().NotEmpty().WithMessage("نام کاربری اجباری می باشد")
                                    .NotEmpty().NotNull()
                                    .Must(IsUserNameUnique).WithMessage("نام کاربری تکراری می باشد");
            //RuleFor(x => x.Email).Empty().EmailAddress().WithMessage("پست الکترونیک غیر مجاز می باشد");
            RuleFor(x => x.PhoneNumber).NotEmpty().WithMessage("تلفن همراه احباری می باشد");
                //Must(PhoneNumberValidator).WithMessage("تلفن همراه غیر مجاز است");
        }

        internal bool IsEmailUnique(ApplicationUser editedApplicationUser, string newValue)
        {
            return _userManager.Users.All(user =>
              user.Equals(editedApplicationUser) || user.Email != newValue);
        }
        internal bool IsUserNameUnique(ApplicationUser editedApplicationUser, string newValue)
        {
            return _userManager.Users.All(user =>
              user.Equals(editedApplicationUser) || user.UserName != newValue);
        }
        internal bool EmailOrPhoneNotEmpty(ApplicationUser model)
        {
            if (string.IsNullOrEmpty(model.Email) && string.IsNullOrEmpty(model.PhoneNumber))
            {
                return false;
            }
            return true;
        }
        internal bool EmailValidator(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }
        internal bool PhoneNumberValidator(string PhoneNumber)
        {
            if (PhoneNumber.Length == 0) return true;
            var reg = Regex.Match(PhoneNumber, @"(0|\+98)?([ ]|-|[()]){0,2}9[1|2|3|4]([ ]|-|[()]){0,2}(?:[0-9]([ ]|-|[()]){0,2}){8}");
            return reg.Success;
        }

    }
}
