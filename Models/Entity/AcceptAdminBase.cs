
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyExchange.Models.Entity
{
    public class AdminBase : Base
    {
        public AdminBase()
        {
        }
        public Nullable<long> AdminId { get; set; }
        public byte VerifyType { get; set; }
        public Nullable<DateTime> AdminConfirmDate { get; set; }
        [ForeignKey("AdminId")]
        public virtual ApplicationUser AdminUser { get; set; }
    }
}
