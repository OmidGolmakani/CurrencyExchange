using CurrencyExchange.CustomException;
using CurrencyExchange.Models.Dto.Admins;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyExchange.Helpers
{
    internal static class Helper
    {
        internal static AdminConfirmDto GetAdminInfo()
        {
            try
            {
                if (Helpers.AppContext.Current.Request.Headers.
                    FirstOrDefault(x => x.Key == "Authorization").Value.FirstOrDefault() == null)
                {
                    throw new MyException("توکن ارسال نشده است");
                }
                var Token = Helpers.AppContext.Current.Request.Headers.
                    FirstOrDefault(x => x.Key == "Authorization").Value.FirstOrDefault().
                    Replace("Bearer", "").Trim();
                var UserId = Helpers.JWTTokenManager.GetUserIdByToken(Token);
                return new AdminConfirmDto()
                {
                    AdminId = UserId,
                    AdminConfirmDate = DateTime.Now,
                    VerifyType = 1
                };
            }
            catch (MyException ex)
            {

                throw ex;
            }
        }
    }
}
