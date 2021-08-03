using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CurrencyExchange.OtherServices.SMS.Enum.MeliPayamak
{
    public class Url
    {
        public enum Type
        {
            SendMessage = 1,
            GetMessages = 2,
            GetDeliveryMessages = 3
        }
    }
}
