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
            RuleFor(x => x.PurchasePrice).NotNull().NotEmpty().WithMessage("مبلغ خرید ارز اجباری می باشد");
            RuleFor(x => x.SalesPrice).NotNull().NotEmpty().WithMessage("مبلغ فروش ارز اجباری می باشد");
            RuleFor(x => x.CurrencyId).NotEmpty().NotNull().WithMessage("نوع ارز را مشخص نمایید");
            RuleFor(x => x.LastChangeDate).NotEmpty().NotNull().WithMessage("تاریخ اجباری می باشد")
                                          .Must(IsLastChangeDateUnique).WithMessage("تاریخ و ساعت تکراری می باشد");
        }

        internal bool IsLastChangeDateUnique(CurrencyChange edited, DateTime newValue)
        {
            return context.CurrencyChanges. All(c =>
              c.Equals(edited) || c.LastChangeDate != newValue);
        }
    }
}
