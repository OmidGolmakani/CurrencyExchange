using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CurrencyExchange.Models.Dto.BankAccounts
{
    public class CUBankAccountDto
    {
        public Nullable<long> Id { get; set; }
        public long UserId { get; set; }
        public byte IdType { get; set; }
        public string Value { get; set; }
    }
}
