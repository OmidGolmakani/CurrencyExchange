using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyExchange.Models.Enum
{
    public class AuthUserItem : Base
    {
        public enum Status
        {
            Waiting = 2,
            Accepted = 3,
            Rejected = 1,
        }
    }
}
