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
    public class Trades : AcceptAdminBase
    {
        [Key]
        public long Id { get; set; }
        public Nullable<long> OrderId { get; set; }
        [Required]
        [StringLength(10)]
        public string BuyDate { get; set; }
        [Required]
        public long BuyNum { get; set; }
        [Required]
        public long UserId { get; set; }
        [Required]
        public int CurrencyId { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        [DataType("decimal(18 ,4)")]
        public decimal InstantPrice { get; set; }
        [Required]
        [DataType("decimal(18 ,4)")]
        public decimal CurrencyPrice { get; set; }
        [Required]
        public byte Status { get; set; }
        [StringLength(500)]
        public string Description { get; set; }
        [ForeignKey("UserId")]
        public virtual ApplicationUser BuyUser { get; set; }
        [ForeignKey("CurrencyId")]
        public virtual Currency  Currency { get; set; }
    }
}
