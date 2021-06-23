
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        public long? AdminAcceptId { get; set; }
        [StringLength(10)]
        public string AdminAcceptDate { get; set; }
        [StringLength(8)]
        public string AdminAcceptTime { get; set; }
        [ForeignKey("AdminAcceptId")]
        public virtual ApplicationUser AdminUser { get; set; }
    }
}
