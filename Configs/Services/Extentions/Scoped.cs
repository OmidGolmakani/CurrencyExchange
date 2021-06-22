using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
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
            return services;
        }
    }
}
