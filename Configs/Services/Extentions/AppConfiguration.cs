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
            //#region SMS Config
            //var SMSConfig = configuration.GetSection("SmsConfigurations");
            //services.Configure<SmsConfig>(SMSConfig);
            //#endregion SMS Config
            //#region Email Config
            //var EmailConfig = configuration.GetSection("EmailConfiguration");
            //services.Configure<EmailConfig>(EmailConfig);
            //#endregion Email Config
            //#region Upload Config
            //var UploadConfig = configuration.GetSection("UploadConfig");
            //services.Configure<UploadConfig>(UploadConfig);
            //#endregion Upload Config
            //#region Payment
            //var PaymentConfig = configuration.GetSection("PaymentConfig");
            //services.Configure<Services.External.Payment.Dto.PaymentConfig>(PaymentConfig);
            //#endregion Payment
            //#region Authentication
            //var AuthorizationConfig = configuration.GetSection("Authentication");
            //services.Configure<AppSettings.Dto.Authentications.Authentication>(AuthorizationConfig);
            //#endregion Authentication
            return services;
        }
    }
}
