using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyExchange.Models.Entity
{
    public class AuthUserItem : Base
    {
        [Key]
        public long Id { get; set; }
        [Required]
        public int AuthItemId { get; set; }
        [Required]
        public long UserId { get; set; }
        [ForeignKey("AuthItemId")]
        public virtual AuthItem AuthItem { get; set; }
        [ForeignKey("UserId")]
        public virtual ApplicationUser AuthUser { get; set; }
    }
}
