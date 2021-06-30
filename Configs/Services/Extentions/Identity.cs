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
                config.Password.RequireDigit = false;
                //config.Password.RequiredLength = 10;
                config.Password.RequireLowercase = false;
                config.Password.RequireUppercase = false;
                config.Password.RequireNonAlphanumeric = false;
                config.User.RequireUniqueEmail = false;
                config.SignIn.RequireConfirmedEmail = false;
                config.SignIn.RequireConfirmedPhoneNumber = true;
            })
            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddUserStore<ApplicationUserStore>()
            .AddRoles<ApplicationRole>()
            .AddDefaultTokenProviders();
            return services;
        }
    }
}
