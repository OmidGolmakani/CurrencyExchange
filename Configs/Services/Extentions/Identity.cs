using CurrencyExchange.Data;
using CurrencyExchange.Models.Entity;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace CurrencyExchange.Configs.Servises.Extentions
{
    public static class Identity
    {
        /// <summary>
        /// Add Identity With All Settings
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddMyIdentity(this IServiceCollection services)
        {
            services.AddIdentity<ApplicationUser, ApplicationRole>(config => {
                config.Password.RequireDigit = true;
                config.Password.RequiredLength = 10;
                config.Password.RequireLowercase = true;
                config.Password.RequireUppercase = true;
                config.Password.RequireNonAlphanumeric = true;
                config.User.RequireUniqueEmail = true;
                config.SignIn.RequireConfirmedEmail = false;
                config.SignIn.RequireConfirmedPhoneNumber = false;
            })
            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddUserStore<ApplicationUserStore>()
            .AddRoles<ApplicationRole>()
            .AddDefaultTokenProviders();
            return services;
        }
    }
}
