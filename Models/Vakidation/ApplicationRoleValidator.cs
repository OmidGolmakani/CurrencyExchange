using CurrencyExchange.Data;
using CurrencyExchange.Models.Entity;
using FluentValidation;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyExchange.Models.Validation
{
    public class ApplicationRoleValidator : AbstractValidator<ApplicationRole>
    {
        private readonly ApplicationDbContext context;
        private readonly UserManager<ApplicationUser> _userManager;
        public ApplicationRoleValidator(ApplicationDbContext dbContext,
                                        UserManager<ApplicationUser> userManager)
        {
            context = dbContext;
            _userManager = userManager;
            RuleFor(x => x.Id).NotNull();
            RuleFor(x => x.Name).NotNull().WithMessage("نام نقش اجباری می باشد");
            RuleFor(x => x.Name).Must(IsNameUnique).WithMessage("نام نقش اجباری می باشد");
        }
        public bool IsNameUnique(ApplicationRole editedName, string newValue)
        {
            return context.Roles.Where(c => c.Id == editedName.Id).All(p =>
                p.Equals(editedName) || p.Name != newValue);
        }
    }
}
