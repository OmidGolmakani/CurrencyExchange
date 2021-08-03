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
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Url { get; set; }
        public List<string> SMSNumbers { get; set; } = new List<string>();
        public List<Pattern> Patterns { get; set; } = new List<Pattern>();
    }
}
