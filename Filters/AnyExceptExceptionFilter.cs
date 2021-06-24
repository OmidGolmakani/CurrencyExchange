using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyExchange.Filter
{
    public class AnyExceptExceptionFilter : Attribute, IAllowAnonymous, IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
            if (context.Result == null)
            {
                return;
            }
            if (!context.Result.GetType().Equals(typeof(ObjectResult))) return;
            context.HttpContext.Response.StatusCode = (((ObjectResult)context.Result).StatusCode ?? (int)System.Net.WebExceptionStatus.UnknownError);
            context.Result = new JsonResult(context.Result);
        }
        public void OnActionExecuting(ActionExecutingContext context)
        {

        }
    }
}
