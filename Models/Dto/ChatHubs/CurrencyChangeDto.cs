using CurrencyExchange.Models.Dto.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyExchange.Models.Dto.ChatHubs
{
    public class CurrencyChangeDto : EmptyBaseDto
    {
        public int CurrencyId { get; set; }
        public decimal CurrencyPrice { get; set; }
    }
}
