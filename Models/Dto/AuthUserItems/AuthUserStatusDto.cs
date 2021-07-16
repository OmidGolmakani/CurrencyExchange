using CurrencyExchange.Models.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyExchange.Models.Dto.AuthUserItems
{
    public class AuthUserStatusDto
    {
        public long UserId { get; set; }
        public byte StatusId { get; set; }
        public string Status { get { return this.GetStatus(); } }
    }
}
