using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CurrencyExchange.Models.Dto.BankAccounts
{
    public class BankAccountDto
    {
        public long Id { get; set; }
        [JsonIgnore]
        public long UserId { get; set; }
        public string UserFullName { get; set; }
        [JsonIgnore]
        public byte IdType { get; set; }
        public string TypeName
        {
            get
            {
                Enum.BankAccount.IdType idType = (Enum.BankAccount.IdType)IdType;
                switch (idType)
                {
                    case Enum.BankAccount.IdType.Account:
                        return "حساب";
                    case Enum.BankAccount.IdType.Card:
                        return "کارت";
                    case Enum.BankAccount.IdType.Shaba:
                        return "شبا";
                    default:
                        return "";
                }
            }
        }
        public string Value { get; set; }
    }
}
