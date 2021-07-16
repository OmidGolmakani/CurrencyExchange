using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyExchange.Models.Dto.AuthUserItems
{
    public class CAuthUserItemsDto
    {
        public long UserId { get; set; }
        public AuthStep1Dto Step1 { get; set; }
        public AuthStep2Dto Step2 { get; set; }
        public AuthStep3Dto Step3 { get; set; }
    }
}
