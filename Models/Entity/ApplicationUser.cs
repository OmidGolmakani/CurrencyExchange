using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CurrencyExchange.Models.Entity
{
    public class ApplicationUser : IdentityUser<long>
    {
        public ApplicationUser()
        {
            Orders = new HashSet<Order>();
            AdminUsers = new HashSet<AcceptAdminBase>();
        }
        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<AcceptAdminBase> AdminUsers { get; set; }
    }
}
