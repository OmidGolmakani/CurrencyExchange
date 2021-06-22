using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CurrencyExchange.Models.Entity
{
    public class Base
    {
        public Base()
        {
            
        }
        public bool Deleted { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? LastModifyDate { get; set; }
    }
}
