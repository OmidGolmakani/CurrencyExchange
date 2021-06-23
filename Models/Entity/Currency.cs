using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyExchange.Models.Entity
{
    [Table("Currency")]
    public class Currency : Base
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public byte CurrencyTypeId { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<CurrencyChange> CurrencyChanges { get; set; }
    }
}
