using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyExchange.Models.Entity
{
    public class AcceptAdminBase : Base
    {
        public AcceptAdminBase()
        {
        }
        public bool AdminAccept { get; set; }
        public long? AdminAcceptId { get; set; }
        public DateTime? AdminAcceptDate { get; set; }
        [ForeignKey("AdminAcceptId")]
        public virtual ApplicationUser AdminUser { get; set; }
    }
}
