using CurrencyExchange.Data;
using CurrencyExchange.Models.Entity;
using FluentValidation;
using Microsoft.AspNetCore.Identity;
using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace CurrencyExchange.Validation
{
    public class CurrencyChangeValidator : AbstractValidator<CurrencyChange>
    {
        private readonly ApplicationDbContext context;
        public CurrencyChangeValidator(ApplicationDbContext dbContext)
        {
            context = dbContext;
            RuleFor(x => x.Id).NotNull();
            RuleFor(x => x.CurrencyChangeId).Must(x => EnumHelper.Helper.EnumValidator<Models.Enum.CurrencyChange.ChangeType>(x)).WithMessage("لطفا نوع را مشخص نمایید");
            RuleFor(x => x.CurrencyPrice).NotNull().NotEmpty().WithMessage("مبلغ ارز اجباری می باشد");
            RuleFor(x => x.CurrencyId).NotEmpty().NotNull().WithMessage("نوع ارز را مشخص نمایید");
            RuleFor(x => x.CreateDate).NotEmpty().NotNull().WithMessage("تاریخ اجباری می باشد");
        }

    }
}
