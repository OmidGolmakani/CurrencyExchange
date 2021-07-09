using CurrencyExchange.CustomException;
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
        internal static void GetAdminInfo()
        {
            try
            {
                var h = Helpers.AppContext.Current.Request.Headers;
            }
            catch (MyException ex)
            {

                throw ex;
            }
        }
    }
}
