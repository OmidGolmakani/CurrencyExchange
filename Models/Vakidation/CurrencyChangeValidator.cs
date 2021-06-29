﻿using CurrencyExchange.Data;
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
            RuleFor(x => x.BuyPrice).NotNull().NotEmpty().WithMessage("مبلغ خرید ارز اجباری می باشد");
            RuleFor(x => x.SalePrice).NotNull().NotEmpty().WithMessage("مبلغ فروش ارز اجباری می باشد");
            RuleFor(x => x.CurrencyId).NotEmpty().NotNull().WithMessage("نوع ارز را مشخص نمایید");
            RuleFor(x => x.CreateDate).NotEmpty().NotNull().WithMessage("تاریخ اجباری می باشد");
        }

    }
}
