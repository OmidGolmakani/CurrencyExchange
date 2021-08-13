using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyExchange.Models.Dto.ApplicationUsers
{
    public class DeActiveUserDto
    {
        public long UserId { get; set; }
        public string Reason { get; set; }
    }
}
