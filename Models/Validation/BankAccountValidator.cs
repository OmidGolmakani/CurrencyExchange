using CurrencyExchange.Data;
using CurrencyExchange.Models.Entity;
using FluentValidation;
using Microsoft.AspNetCore.Identity;
using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace CurrencyExchange.Validation
{
    public class BankAccountValidator : AbstractValidator<BankAccount>
    {
        private readonly ApplicationDbContext context;
        public BankAccountValidator(ApplicationDbContext dbContext)
        {
            context = dbContext;
            RuleFor(x => x.Id).NotNull();
            RuleFor(x => x.IdType).Must(x => Models.EnumHelper.Helper.EnumValidator<Models.Enum.BankAccount.IdType>(x)).WithMessage("لطفا نوع را مشخص نمایید");
            RuleFor(x => x.Value).NotEmpty().WithMessage("مقدار اجباری می باشد");
        }
    }
}
