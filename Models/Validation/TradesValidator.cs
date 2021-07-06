using CurrencyExchange.Data;
using CurrencyExchange.Models.Entity;
using FluentValidation;
using Microsoft.AspNetCore.Identity;
using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace CurrencyExchange.Validation
{
    public class TradesValidator : AbstractValidator<Trades>
    {
        private readonly ApplicationDbContext context;
        public TradesValidator(ApplicationDbContext dbContext)
        {
            context = dbContext;
            RuleFor(x => x.Id).NotNull();
            RuleFor(x => x.TradeDate).NotEmpty().NotNull().WithMessage("تاریخ سفارش اجباری می باشد");
            RuleFor(x => x.Quantity).NotNull().NotEmpty().WithMessage("تعداد اجباری می باشد");
            RuleFor(x => x.Quantity).Must(x => x <= 0 ? false : true).WithMessage("تعداد نمیتواند کوچکتر مساوی صفر باشد");
            RuleFor(x => x.CurrencyPrice).NotNull().NotEmpty().WithMessage("قیمت ارز اجباری می باشد");
            RuleFor(x => x.InstantPrice).NotNull().Empty().WithMessage("قیمت لحظه ای ارز اجباری می باشد");
            RuleFor(x => x.Status).NotEmpty().NotNull().WithMessage("وضعیت درخواست اجباری می باشد");
        }

    }
}
