using CurrencyExchange.Models.Dto.Admins;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyExchange.Models.Dto.AuthUserItems
{
    public class AuthUserItemDto : AdminConfirmDto
    {
        public long Id { get; set; }
        public int AuthItemId { get; set; }
        public string AuthName { get; set; }
        public long UserId { get; set; }
        public string UserFullName { get; set; }
    }
}
