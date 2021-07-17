using CurrencyExchange.Models.Dto.ApplicationUsers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyExchange.Models.Helper
{
    internal static class ApplicationUserFunc
    {
        internal static string GetUserFullName(string Name, string Family)
        {
            return string.Format("{0} {1}", Name, Family).Trim();
        }
        internal static string GetUserFullName(this ApplicationUserDto x)
        {
            return GetUserFullName(x.Name, x.Family);
        }
        internal static string GetUserFullName(this Models.Entity.ApplicationUser x)
        {
            return GetUserFullName(x.Name, x.Family);
        }
        internal static string GetAuthStatus(this ApplicationUserDto x)
        {
            return Helper.AuthUserItemFunc.GetStatus((x.AuthStatusId ?? 0));
        }
        internal static string GetUserFullName(this Models.Dto.ApplicationUsers.ApplicationUserAuthDto x)
        {
            return GetUserFullName(x.Name, x.Family);
        }
    }
}
