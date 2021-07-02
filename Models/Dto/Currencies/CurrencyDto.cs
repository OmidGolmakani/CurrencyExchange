using CurrencyExchange.Models.Dto.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyExchange.Models.Dto.Currencies
{
    public class CurrencyDto : BaseDto
    {
        public int Id { get; set; }
        public byte CurrencyTypeId { get; set; }
        public string CurrencyTypeName
        {
            get
            {
                Enum.Currency.CurrencyTypeId currencyType = (Enum.Currency.CurrencyTypeId)CurrencyTypeId;
                switch (currencyType)
                {
                    case Enum.Currency.CurrencyTypeId.Dollar:
                        return "دلار";
                    case Enum.Currency.CurrencyTypeId.Tether:
                        return "تتر";
                    default:
                        return "";
                }
            }
        }
        public string CurrencyAbbreviationName { get; set; }
    }
}
