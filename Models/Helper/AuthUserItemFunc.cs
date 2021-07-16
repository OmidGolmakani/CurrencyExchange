using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyExchange.Models.Helper
{
    public static class AuthUserItemFunc
    {
        internal static string GetStatus(this Models.Entity.AuthUserItem status)
        {
            Enum.AuthUserItem.Status authStatus = (Enum.AuthUserItem.Status)status.Status;
            return GetStatus(status);
        }
        internal static string GetStatus(Enum.AuthUserItem.Status status)
        {
            switch (status)
            {
                case Enum.AuthUserItem.Status.Waiting:
                    return "در انتظار تایید";
                case Enum.AuthUserItem.Status.Accepted:
                    return "تایید شده";
                case Enum.AuthUserItem.Status.Rejected:
                    return "رد شده";
                default:
                    return "";
            }
        }
    }
}
