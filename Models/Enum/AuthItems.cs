using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyExchange.Models.Enum
{
    public class AuthItems
    {
        public enum AuthTypeId
        {
            PhoneNumber = 1,
            Tel = 2,
            BirthCertificate = 3,
            NationalCard = 4,
            BankCard = 5,
            UserPicture = 6
        }
    }
}
