using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyExchange.Models.Entity
{
    [Table("Trades")]
    public class Trades : Base
    {
        [Key]
        public long Id { get; set; }
        public Nullable<long> OrderId { get; set; }
        [Required]
        public DateTime TradeDate { get; set; }
        [Required]
        public long TradeNum { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        [DataType("decimal(18 ,4)")]
        public decimal CurrencyPrice { get; set; }
        [StringLength(500)]
        public string Description { get; set; }
        [ForeignKey("OrderId")]
        public virtual Order Order { get; set; }
    }
}
