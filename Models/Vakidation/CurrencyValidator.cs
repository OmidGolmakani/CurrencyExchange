using CurrencyExchange.Data;
using CurrencyExchange.Models.Entity;
using FluentValidation;
using Microsoft.AspNetCore.Identity;
using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace CurrencyExchange.Validation
{
    public class CurrencyValidator : AbstractValidator<Currency>
    {
        private readonly ApplicationDbContext context;
        public CurrencyValidator(ApplicationDbContext dbContext)
        {
            context = dbContext;
            RuleFor(x => x.Id).NotNull();
            RuleFor(x => x.CurrencyTypeId).Must(x => EnumHelper.Helper.EnumValidator<Models.Enum.Currency>(x)).WithMessage("لطفا نوع ارز را مشخص نمایید"); 
        }

    }
}
