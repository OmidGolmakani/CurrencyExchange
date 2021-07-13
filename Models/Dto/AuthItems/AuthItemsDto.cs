using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyExchange.Models.Dto.AuthItems
{
    public class AuthItemDto : Base.BaseDto
    {
        public int Id { get; set; }
        public byte AuthTypeId { get; set; }
        public byte Order { get; set; }
        public string AuthName { get; set; }
        public bool Required { get; set; }
        public string Description { get; set; }
    }
}
