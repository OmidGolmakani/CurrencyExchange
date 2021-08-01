using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyExchange.OtherServices.SMS.Dto
{
    public class SMSConfig
    {
        public string APIKey { get; set; }
        public List<Pattern> Patterns { get; set; }
    }
}
