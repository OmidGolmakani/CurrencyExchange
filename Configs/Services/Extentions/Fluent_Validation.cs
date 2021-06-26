using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CurrencyExchange.Configs.Servises.Extentions
{
    public static class Fluent_Validation
    {
        /// <summary>
        /// Config FluentValidation
        /// </summary>
        /// <param name="service"></param>
        /// <returns></returns>
        public static IServiceCollection FluentValidationConfig(this IServiceCollection services)
        {
            services.AddControllersWithViews().AddFluentValidation();

            return services;
        }
    }
}
