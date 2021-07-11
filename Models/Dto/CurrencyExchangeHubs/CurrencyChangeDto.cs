using CurrencyExchange.Models.Dto.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyExchange.Models.Dto.CurrencyExchangeHub
{
    public class CurrencyChangeDto : EmptyBaseDto
    {
        public int CurrencyId { get; set; }
        public string CurrencyNaame { get; set; }
        public decimal PurchasePrice { get; set; }
        public decimal SalesPrice { get; set; }
        public string LastChangeSolarDate { get; set; }
        public string LastChangeTime { get; set; }
    }
}
