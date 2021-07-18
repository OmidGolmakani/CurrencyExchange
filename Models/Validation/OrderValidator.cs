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
            RuleFor(x => x.OrderDate).NotEmpty().NotNull().WithMessage("تاریخ سفارش اجباری می باشد");
            RuleFor(x => x.UserId).NotNull().NotEmpty().WithMessage("لطفا کاربر را انتخاب نمایید");
            RuleFor(x => x.CurrencyId).NotEmpty().NotNull().WithMessage("نوع ارز اجباری می باشد")
                .Must(CurrencyValidator).WithMessage("واحد ارز مشخص نشده است");
            RuleFor(x => x.Quantity).NotNull().NotEmpty().WithMessage("تعداد اجباری می باشد");
            RuleFor(x => x.Quantity).Must(x => x <= 0 ? false : true).WithMessage("تعداد نمیتواند کوچکتر مساوی صفر باشد");
            RuleFor(x => x.CurrencyPrice).NotNull().NotEmpty().WithMessage("قیمت ارز اجباری می باشد");
            RuleFor(x => x.InstantPrice).NotNull().NotEmpty().WithMessage("قیمت لحظه ای ارز اجباری می باشد");
            RuleFor(x => x.OrderTypeId).Must(x => Models.EnumHelper.Helper.EnumValidator<Models.Enum.Order.OrderType>(x)).WithMessage("نوع درخواست را مشخص نمایید");
            RuleFor(x => x.Status).NotEmpty().NotNull()
                .Must(x => Models.EnumHelper.Helper.EnumValidator<Models.Enum.Order.Status>(x)).WithMessage("وضعیت درخواست اجباری می باشد");

        }
        internal bool IsOrderNumUnique(Order editedOrder, long newValue)
        {
            return context.Orders.All(order =>
              order.Equals(editedOrder) || order.OrderNum != newValue);
        }
        internal bool CurrencyValidator(int CurrencyId)
        {
            return context.Currencies.Count(x => x.Id == CurrencyId) == 0 ? false : true;
        }
        internal bool UserValidator(int UserId)
        {
            return context.Users.Count(x => x.Id == UserId) == 0 ? false : true;
        }
    }
}
