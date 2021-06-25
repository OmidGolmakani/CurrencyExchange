using CurrencyExchange.Data;
using CurrencyExchange.Models.Entity;
using FluentValidation;
using Microsoft.AspNetCore.Identity;
using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace CurrencyExchange.Validation
{
    public class OrderValidator : AbstractValidator<Order>
    {
        private readonly ApplicationDbContext context;
        public OrderValidator(ApplicationDbContext dbContext)
        {
            context = dbContext;
            RuleFor(x => x.Id).NotNull();
            RuleFor(x => x.OrderNum).NotNull().NotEmpty().WithMessage("شماره درخواست اجباری می باشد");
            RuleFor(x => x.OrderNum).Must(IsOrderNumUnique).WithMessage("شماره درخواست تکراری می باشد");
            RuleFor(x => x.CreateDate).NotEmpty().NotNull().WithMessage("تاریخ سفارش اجباری می باشد");
            RuleFor(x => x.UserId).NotNull().NotEmpty().WithMessage("لطفا کاربر را انتخاب نمایید");
            RuleFor(x => x.CurrencyId).NotEmpty().NotNull().WithMessage("نوع ارز اجباری می باشد");
            RuleFor(x => x.Quantity).NotNull().NotEmpty().WithMessage("تعداد اجباری می باشد");
            RuleFor(x => x.Quantity).Must(x => x <= 0 ? false : true).WithMessage("تعداد نمیتواند کوچکتر مساوی صفر باشد");
            RuleFor(x => x.CurrencyPrice).NotNull().NotEmpty().WithMessage("قیمت ارز اجباری می باشد");
            RuleFor(x => x.InstantPrice).NotNull().Empty().WithMessage("قیمت لحظه ای ارز اجباری می باشد");
            RuleFor(x => x.Status).NotEmpty().NotNull().WithMessage("وضعیت درخواست اجباری می باشد");
        }
        internal bool IsOrderNumUnique(Order editedOrder, long newValue)
        {
            return context.Orders.All(order =>
              order.Equals(editedOrder) || order.OrderNum != newValue);
        }

    }
}
