using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyExchange.Models.Entity
{

    [Table("CurrencyChange")]
    public class CurrencyChange : Base
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int CurrencyId { get; set; }
        [Required]
        [DataType("decimal(18 ,4)")]
        public decimal PurchasePrice { get; set; }
        [Required]
        [DataType("decimal(18 ,4)")]
        public decimal SalesPrice { get; set; }
        [Required]
        public DateTime LastChangeDate { get; set; }
        [ForeignKey("CurrencyId")]
        public virtual Currency Currency { get; set; }
    }
}
