using CurrencyExchange.Data;
using CurrencyExchange.Models.Entity;
using FluentValidation;
using Microsoft.AspNetCore.Identity;
using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace CurrencyExchange.Validation
{
    public class AuthUserItemValidator : AbstractValidator<AuthUserItem>
    {
        private readonly ApplicationDbContext context;
        public AuthUserItemValidator(ApplicationDbContext dbContext)
        {
            context = dbContext;
            RuleFor(x => x.Id).NotNull();
            RuleFor(x => x.UserId).Must(UserIdValidation).WithMessage("کاربر اجباری می باشد");
            RuleFor(x => x.AuthItemId).Must(AuthItemIdValidation).WithMessage("نوع احراز هویت مشخص نشده است");
        }
        private bool UserIdValidation(long UserId)
        {
            return context.Users.Find(UserId) == null ? false : true;
        }
        private bool AuthItemIdValidation(int AuthId)
        {
            return context.AuthItems.Find(AuthId) == null ? false : true;
        }
    }
}
