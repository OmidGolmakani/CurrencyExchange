using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyExchange.Model.Entity
{
    public class AcceptAdminBase : Base
    {
        public AcceptAdminBase()
        {
        }
        public bool AdminAccept { get; set; }
        public long? AdminAcceptId { get; set; }
        public DateTime? AdminAcceptDate { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}
