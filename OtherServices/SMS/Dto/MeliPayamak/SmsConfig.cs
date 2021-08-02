using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CurrencyExchange.OtherServices.SMS.Dto.MeliPayamak
{
    public class SmsConfig
    {
        public Authentication Authentication { get; set; }
        public List<string> SmsNumbers { get; set; } = new List<string>();
        public List<Url> Urls { get; set; }
    }
}
