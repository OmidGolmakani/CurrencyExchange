using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyExchange.OtherServices.SMS.Dto
{
    public class SendWithPattern
    {
        public string op { get; set; }
        public string user{ get; set; }
        public string pass { get; set; }
        public string fromNum { get; set; }
        public string toNum { get; set; }
        public string patternCode { get; set; }
        public SMS.Dto.InputData inputData { get; set; } = new InputData();

    }
}
