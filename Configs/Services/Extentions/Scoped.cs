using CurrencyExchange.Models.Dto.CurrencyChanges;
using CurrencyExchange.Models.Entity;
using CurrencyExchange.Models.Repository.Interfaces;
using CurrencyExchange.Models.Repository.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.DependencyInjection;

namespace CurrencyExchange.Configs.Servises.Extentions
{
    public static class Scoped
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddScopeds(this IServiceCollection services)
        {
            #region Identity
            services.AddScoped<UserManager<ApplicationUser>>();
            services.AddScoped<RoleManager<ApplicationRole>>();
            services.AddScoped<ApplicationUser>();
            services.AddScoped<ApplicationRole>();
            services.AddScoped<ApplicationUserRole>();
            services.AddScoped<ApplicationRoleClaim>();
            services.AddScoped<ApplicationUserClaim>();
            services.AddScoped<ApplicationUserLogin>();
            services.AddScoped<ApplicationUserToken>();
            #endregion Identity
            services.AddScoped<Account, Account>();
            services.AddScoped<ChatHub, ChatHub>();
            services.AddScoped(typeof(IRepository< >),typeof(Repository< >));
            services.AddScoped(typeof(Repository<Models.Entity.Order>), typeof(Repository<Models.Entity.Order>));
            services.AddScoped(typeof(IOrder), typeof(Models.Repository.Services.Order));
            services.AddScoped<Models.Repository.Services.Order, Models.Repository.Services.Order>();
            return services;
        }
    }
}
