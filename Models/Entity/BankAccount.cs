using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyExchange.Models.Entity
{
    [Table("BankAccount")]
    public class BankAccount : AdminBase
    {
        [Key]
        public long Id { get; set; }
        [Required]
        public long UserId { get; set; }
        public Nullable<long> AuthItemId { get; set; }
        [Required]
        public byte IdType { get; set; }
        [Required]
        [StringLength(24)]
        public string Value { get; set; }
        [ForeignKey("UserId")]
        public virtual ApplicationUser User { get; set; }
        [ForeignKey("AuthItemId")]
        public virtual AuthUserItem AuthUserItem { get; set; }
    }
}
