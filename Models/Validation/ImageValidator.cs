using CurrencyExchange.Data;
using CurrencyExchange.Models.Entity;
using FluentValidation;
using Microsoft.AspNetCore.Identity;
using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace CurrencyExchange.Validation
{
    public class ImageValidator : AbstractValidator<Image>
    {
        private readonly ApplicationDbContext context;
        public ImageValidator(ApplicationDbContext dbContext)
        {
            context = dbContext;
            RuleFor(x => x.Id).NotNull();
            RuleFor(x => x.UserId).NotNull().NotEmpty().WithMessage("کاربر مشخص نشده است");
            RuleFor(x => x.FileName).NotNull().NotEmpty().WithMessage("مسیر عکس مشخص نشده است");
            RuleFor(x => x.ImageTypeId).Must(x => Models.EnumHelper.Helper.EnumValidator<Models.Enum.Image.Type>(x)).WithMessage("نوع تصویر مشخص نشده است");
        }

    }
}
