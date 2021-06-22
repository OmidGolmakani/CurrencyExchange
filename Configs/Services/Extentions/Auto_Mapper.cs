using Microsoft.Extensions.DependencyInjection;
using Selle.WebApp.Configs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CurrencyExchange.Configs.Servises.Extentions
{
    public static class Auto_Mapper
    {
        public static IServiceCollection AutoMapperConfig(this IServiceCollection services)
        {
            var Config = new AutoMapper.MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new AutoMapperProfile());
            });
            var mapper = Config.CreateMapper();
            services.AddSingleton(mapper);
            return services;
        }
    }
}
