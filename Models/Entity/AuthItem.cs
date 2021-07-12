using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyExchange.Models.Entity
{
    public class AuthItem : Base
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public byte AuthTypeId { get; set; }
        [Required]
        [StringLength(150)]
        public string AuthName { get; set; }
        [Required]
        public byte Order { get; set; }
        [Required]
        [DefaultValue(true)]
        public bool Required { get; set; }
        [StringLength(500)]
        public string Description { get; set; }
        public virtual ICollection<AuthUserItem> AuthUserItems { get; set; }
    }
}
