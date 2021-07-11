using CurrencyExchange.Models.Dto.CurrencyChanges;
using CurrencyExchange.Models.Entity;
using CurrencyExchange.Models.Repository.Interfaces;
using CurrencyExchange.Models.Repository.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

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
            services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();
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
            services.AddScoped<CurrencyExchangeHub, CurrencyExchangeHub>();
            services.AddScoped(typeof(IRepository<,>), typeof(Repository<,>));
            #region Order
            services.AddScoped(typeof(Repository<Models.Entity.Order, long>), typeof(Repository<Models.Entity.Order, long>));
            services.AddScoped(typeof(IOrder), typeof(Models.Repository.Services.Order));
            services.AddScoped<Models.Repository.Services.Order, Models.Repository.Services.Order>();
            #endregion Order
            #region Trades
            services.AddScoped(typeof(Repository<Models.Entity.Trades, long>), typeof(Repository<Models.Entity.Trades, long>));
            services.AddScoped(typeof(ITrades<long>), typeof(Models.Repository.Services.Trades));
            services.AddScoped<Models.Repository.Services.Trades, Models.Repository.Services.Trades>();
            #endregion Trades
            #region Currency
            services.AddScoped(typeof(Repository<Models.Entity.Currency, int>), typeof(Repository<Models.Entity.Currency, int>));
            services.AddScoped(typeof(ICurrency), typeof(Models.Repository.Services.Currency));
            services.AddScoped<Models.Repository.Services.Currency, Models.Repository.Services.Currency>();
            #endregion Currency
            return services;
        }
    }
}
