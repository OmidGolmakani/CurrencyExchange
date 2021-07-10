using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyExchange.Models.Dto.Admins
{
    public class AdminConfirmDto
    {
        public long AdminId { get; set; }
        public DateTime AdminConfirmDate { get; set; }
        public byte VerifyType { get; set; }
    }
}
