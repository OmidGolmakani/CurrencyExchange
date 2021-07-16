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
            Waiting = 1,
            Accepted = 2,
            Rejected = 3,
        }
    }
}
