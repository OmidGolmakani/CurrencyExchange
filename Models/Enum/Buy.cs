using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CurrencyExchange.Models.Enum
{
    public class Buy : Base
    {
        public enum Status
        {
            AwaitingConfirmation = 1,
            Confirmation = 2
        }
    }
}
