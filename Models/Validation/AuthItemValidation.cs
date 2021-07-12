using CurrencyExchange.Data;
using CurrencyExchange.Models.Entity;
using FluentValidation;
using Microsoft.AspNetCore.Identity;
using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace CurrencyExchange.Validation
{
    public class AuthItemValidation : AbstractValidator<AuthItem>
    {
        private readonly ApplicationDbContext context;
        public AuthItemValidation(ApplicationDbContext dbContext)
        {
            context = dbContext;
            RuleFor(x => x.Id).NotNull();
            RuleFor(x => x.AuthName).NotEmpty().NotNull().WithMessage("نام آیتم احراز هویت اجباری می باشد");
            RuleFor(x => x.AuthTypeId).Must(x => Models.EnumHelper.Helper.EnumValidator<Models.Enum.AuthItems>(x)).WithMessage("لطفا نوع احراز هویت را مشخص نمایید");
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
