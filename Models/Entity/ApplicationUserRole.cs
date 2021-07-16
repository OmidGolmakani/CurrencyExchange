using Microsoft.AspNetCore.Identity;
namespace CurrencyExchange.Models.Entity
{
    public class ApplicationUserRole : IdentityUserRole<long>
    {
        public virtual ApplicationUser ApplicationUser { get; set; }
        public virtual ApplicationRole Role { get; set; }
    }
}
