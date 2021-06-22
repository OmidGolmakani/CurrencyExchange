using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace CurrencyExchange.Models.Entity
{
    public class ApplicationRole : IdentityRole<long>
    {
        public ApplicationRole()
        {
            Permissions = new HashSet<RolePermission>();
        }

        public virtual ICollection<RolePermission> Permissions { get; set; }
    }
}
