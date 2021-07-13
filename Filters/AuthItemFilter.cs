using CurrencyExchange.CustomException.Dto;
using CurrencyExchange.Models.Repository.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyExchange.Filters
{
    public class AuthItemFilter : Attribute, IActionFilter
    {
        private readonly IAuthUserItem _authUserItemSrv;

        public AuthItemFilter(IAuthUserItem authUserItemSrv)
        {
            this._authUserItemSrv = authUserItemSrv;
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            throw new NotImplementedException();
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            if (context.Result == null)
            {
                return;
            }
            var User = Helpers.JWTTokenManager.GetUserIdByToken(Helpers.JWTTokenManager.GetTokenFromRequest());
            var Result = new JsonResult(new ErrorDto());
            if (User <=0)
            {
                var Err = new ErrorDto()
                {
                    Message = "کاربر مورد نظر جهت بررسی احراز هویت یافت نشد",
                    StatusCode = context.HttpContext.Response.StatusCode
                };

                Result.StatusCode = (int)System.Net.HttpStatusCode.Unauthorized;
                Result.Value = Err;
                context.Result = Result;
            }
            if (_authUserItemSrv.IsCompleteAuthUsers(User).Result == false)
            {
                var Err = new ErrorDto()
                {
                    Message = "جهت انجام این عملیات باید مراحل احراز هویت خود را کامل نمایید",
                    StatusCode = context.HttpContext.Response.StatusCode
                };

                Result.StatusCode = (int)System.Net.HttpStatusCode.Locked;
                Result.Value = Err;
                context.Result = Result;
            }
            if (!context.Result.GetType().Equals(typeof(ObjectResult))) return;
            context.HttpContext.Response.StatusCode = (((ObjectResult)context.Result).StatusCode ?? (int)System.Net.WebExceptionStatus.UnknownError);
            context.Result = new JsonResult(context.Result);
        }
    }
}
