using CurrencyExchange.CustomException;
using CurrencyExchange.CustomException.Dto;
using CurrencyExchange.Data;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;
using System.Net;
using System.Threading.Tasks;

namespace CurrencyExchange.Filter
{
    public class CustomExceptionFilter : ExceptionFilterAttribute
    {

        public override Task OnExceptionAsync(ExceptionContext context)
        {
            try
            {
                ErrorDto Err = null;
                if (context.Exception != null)
                {
                    if (context.Exception.GetType().Equals(typeof(FluentValidation.ValidationException)) == true ||
                    context.Exception.GetType().Equals(typeof(MyException)) == true)
                    {
                        context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                        Err = new ErrorDto()
                        {
                            Message = context.Exception.Message,
                            StatusCode = context.HttpContext.Response.StatusCode
                        };
                        //context.Result = new JsonResult(Err);
                    }
                    else
                    {
                        var dbcontext = context.HttpContext.RequestServices.GetRequiredService<ApplicationDbContext>();
                        MyException ex = (MyException)context.Exception;
                        //dbcontext.ErrorLogs.Add(new Model.Entity.ErrorLog()
                        //{
                        //    ExceptionDate = DateTime.Now,
                        //    ExceptionMessage = ex.Message,
                        //    ExceptionSource = ex.StackTrace,
                        //    ExceptionType = ex.GetType().Name,
                        //    ExceptionURL = context.HttpContext.Request.Path.Value
                        //});
                        if (ex.InnerException != null)
                        {
                            ex = (MyException)ex.InnerException;
                            while (ex != null)
                            {
                                //dbcontext.ErrorLogs.Add(new Models.Entity.ErrorLog()
                                //{
                                //    ExceptionDate = DateTime.Now,
                                //    ExceptionMessage = ex.Message,
                                //    ExceptionSource = ex.StackTrace,
                                //    ExceptionType = ex.GetType().Name,
                                //    ExceptionURL = context.HttpContext.Request.Path.Value
                                //});
                                ex = (MyException)ex.InnerException;
                            }
                        }
                        //var Result = dbcontext.SaveChangesAsync();
                        //Result.Wait();
                    }
                }
                return base.OnExceptionAsync(context);
            }
            catch (MyException ex)
            {
                throw new MyException("", ex);
            }
        }
    }
}
