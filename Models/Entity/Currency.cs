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
        [Required]
        [MaxLength(5)]
        public string CurrencyAbbreviationName { get; set; }
        [DataType("decimal(18 ,4)")]
        public Nullable<decimal> PurchasePrice { get; set; }
        [DataType("decimal(18 ,4)")]
        public Nullable<decimal> SalesPrice { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<Trades> Trades { get; set; }
        public virtual ICollection<CurrencyChange> CurrencyChanges { get; set; }
    }
}
