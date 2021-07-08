using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using CurrencyExchange.CustomException;
using CurrencyExchange.CustomException.Dto;
using CurrencyExchange.Helper;

namespace CurrencyExchange.CustomException.Middlewere
{
    public static class ExceptionMiddlewereException
    {
        public static void ConfigureExceptionHandler(this IApplicationBuilder app, ILogger<Startup> logger)
        {

            app.UseExceptionHandler(a => a.Run(async context =>
            {
                var exceptionHandlerPathFeature = context.Features.Get<IExceptionHandlerPathFeature>();
                var ex = exceptionHandlerPathFeature.Error;
                ErrorDto Err = null;


                if (ex.GetType().Equals(typeof(MyException)) == true)
                {
                    Err = new ErrorDto()
                    {
                        Message = ex.Message,
                        StatusCode = context.Response.StatusCode
                    };
                }
                else if (ex.GetType().Equals(typeof(FluentValidation.ValidationException)) == true)
                {
                    Err = new ErrorDto()
                    {
                        StatusCode = context.Response.StatusCode,
                        Message = (ex as FluentValidation.ValidationException).Errors.Select(x => x.ErrorMessage).ToList().ListToString()
                    };
                }
                else
                {
                    Err = new ErrorDto()
                    {
                        Message = "یک خطای ناشناخته رخ داده است.جزئیات خطا به مدیران سایت گزارش داده شد",
                        StatusCode = (int)System.Net.WebExceptionStatus.UnknownError
                    };
                    using (EventLog eventLog = new EventLog("Application"))
                    {
                        eventLog.Source = "Application";
                        eventLog.WriteEntry(ex.Message, EventLogEntryType.Error, 101, 1);
                    }
                }
                var result = JsonConvert.SerializeObject(Err);
                context.Response.ContentType = "application/json";
                await context.Response.WriteAsync(result);
            }));
            app.UseHsts();
        }
    }
}
