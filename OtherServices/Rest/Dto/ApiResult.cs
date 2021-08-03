using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyExchange.OtherServices.Rest.Dto
{
    public class ApiResult<T>
    {
        public string Value { get; set; }
        public int RetStatus { get; set; }
        public string StrRetStatus { get; set; }
        public List<T> Data { get; set; }
    }
}
