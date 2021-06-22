using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyExchange.Models.Entity
{
    [Table("RolePermission")]
    public class RolePermission : Base
    {
        public RolePermission()
        {

        }
        public int Id { get; set; }
        public long RoleId { get; set; }
        [StringLength(500)]
        public string Url { get; set; }
        [StringLength(500)]
        [Required]
        public string Token { get; set; }
        [ForeignKey("RoleId")]
        [Required]
        public virtual ApplicationRole Role { get; set; }
    }
}
