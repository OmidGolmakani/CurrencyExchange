using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyExchange.Models.Dto.Currencies
{
    public class CUCurrencyDto
    {
        public Nullable<int> Id { get; set; }
        public byte CurrencyTypeId { get; set; }
        public string CurrencyAbbreviationName { get; set; }
    }
}

