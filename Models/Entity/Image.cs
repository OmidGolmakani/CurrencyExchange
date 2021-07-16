using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyExchange.Models.Entity
{
    public class Image : AdminBase
    {
        [Key]
        public long Id { get; set; }
        [Required]
        public long UserId { get; set; }
        public Nullable<long> AuthUserItemId { get; set; }
        [Required]
        public byte ImageTypeId { get; set; }
        [MaxLength(200)]
        [Required]
        public string FileName { get; set; }
        [MaxLength(500)]
        public string Description { get; set; }
        [ForeignKey("UserId")]
        public virtual ApplicationUser User { get; set; }
        [ForeignKey("AuthUserItemId")]
        public virtual AuthUserItem AuthUserItem  { get; set; }
    }
}
