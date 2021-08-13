using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyExchange.Models.Enum
{
    public class AuthItems : Base
    {
        public enum AuthTypeId
        {
            BirthCertificate = 1,
            NationalCard = 2,
            BankCard = 3,
            UserPicture = 4,
            PhoneNumber = 5,
            Tel = 6,
            ShebaNo = 7
        }
    }
}
