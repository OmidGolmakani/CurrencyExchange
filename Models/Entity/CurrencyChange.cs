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
        public int CurrencyId { get; set; }
        [Required]
        [DataType("decimal(18 ,4)")]
        public decimal CurrencyPrice { get; set; }
        [Required]
        [StringLength(10)]
        public string LastChangeDate { get; set; }
        [Required]
        [StringLength(8)]
        public int LastChangeTime { get; set; }
        [ForeignKey("CurrencyId")]
        public virtual Currency Currency { get; set; }
    }
}
