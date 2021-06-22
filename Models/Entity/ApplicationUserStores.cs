using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using CurrencyExchange.Data;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;

namespace CurrencyExchange.Model.Entity
{
    public class ApplicationUserStore : UserStore<ApplicationUser,
                                                  ApplicationRole, 
                                                  ApplicationDbContext, 
                                                  long, 
                                                  ApplicationUserClaim,
                                                  ApplicationUserRole, 
                                                  ApplicationUserLogin, 
                                                  ApplicationUserToken, 
                                                  ApplicationRoleClaim>
    {
        public ApplicationUserStore(ApplicationDbContext context, IdentityErrorDescriber describer = null) : base(context, describer)
        {
        }
    }
}
