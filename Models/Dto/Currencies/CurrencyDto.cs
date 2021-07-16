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
                return Helper.CurrencyFunc.GetCurrncyName(CurrencyTypeId);
            }
        }
        public string CurrencyAbbreviationName { get; set; }
        public Nullable<decimal> PurchasePrice { get; set; }
        public Nullable<decimal> SalesPrice { get; set; }
    }
}
