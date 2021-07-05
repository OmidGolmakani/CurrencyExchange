using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CurrencyExchange.Models.Dto.ErrorLogs
{
    public class ErrorLogDto
    {
        [JsonIgnore]
        public long Id { get; set; }
        public string Ip { get; set; }
        public string Browser { get; set; }
        public DateTime ExceptionDate { get; set; }
        public string ExceptionMessage { get; set; }
        public string ExceptionType { get; set; }
        public string ExceptionSource { get; set; }
        public string ExceptionURL { get; set; }
    }
}
