using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyExchange.Models.Entity
{
    public class Currency:Base
    {
        public int Id { get; set; }
        public byte CurrencyTypeId{ get; set; }
    }
}
