using CurrencyExchange.Model.Entity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CurrencyExchange.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser,
                                                          ApplicationRole,
                                                          long,
                                                          ApplicationUserClaim,
                                                          ApplicationUserRole,
                                                          ApplicationUserLogin,
                                                          ApplicationRoleClaim,
                                                          ApplicationUserToken>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
        public virtual DbSet<RolePermission> RolePermissions { get; set; }
        public virtual DbSet<Currency> Laws { get; set; }
    }
}
