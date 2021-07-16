using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyExchange.Models.Helper
{
    internal static class CurrencyFunc
    {
        internal static string GetCurrncyName(Enum.Currency.CurrencyTypeId currency)
        {
            switch (currency)
            {
                case Enum.Currency.CurrencyTypeId.Tether:
                    return "تتر";
                default:
                    return "";
            }
        }
        internal static string GetCurrncyName(byte currency)
        {
            Enum.Currency.CurrencyTypeId currencyType = (Enum.Currency.CurrencyTypeId)currency;
            return GetCurrncyName(currencyType);

        }
    }
}
