using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CurrencyExchange.Models.Entity
{
    [Table("ErrorLog")]
    public class ErrorLog
    {
        public long Id { get; set; }
        public DateTime ExceptionDate { get; set; }
        public string ExceptionMessage { get; set; }
        [MaxLength(200)]
        public string ExceptionType { get; set; }
        public string ExceptionSource { get; set; }
        [MaxLength(200)]
        public string ExceptionURL { get; set; }
    }
}
