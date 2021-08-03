using CurrencyExchange.OtherServices.FileTransfer.Dto;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CurrencyExchange.Configs.Servises.Extentions
{
    public static class AppConfiguration
    {
        /// <summary>
        /// Get Configuratins From AppSettings.json
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        /// <returns></returns>
        public static IServiceCollection AppSettings(this IServiceCollection services, IConfiguration configuration)
        {
            #region Upload Config
            var UploadConfig = configuration.GetSection("UploadConfig");
            services.Configure<UploadConfig>(UploadConfig);
            #endregion Upload Config
            #region SMS Config
            var SMSConfig = configuration.GetSection("SMSConfig");
            services.Configure<OtherServices.SMS.Dto.SMSConfig>(SMSConfig);

            var SMSConfig1 = configuration.GetSection("SmsConfigurations");
            services.Configure<OtherServices.SMS.Dto.MeliPayamak.SmsConfig>(SMSConfig1);
            #endregion SMS Config
            return services;
        }
    }
}
