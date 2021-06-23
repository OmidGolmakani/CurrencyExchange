using CurrencyExchange.Models.Entity;
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
            #region Db Logigs
            #region Currency
            builder.Entity<Currency>().HasMany(Orders => Orders.Orders)
                .WithOne(Currency => Currency.Currency).OnDelete(DeleteBehavior.NoAction);
            #endregion Currency
            #region Application User
            ///Order
            builder.Entity<ApplicationUser>().HasMany(Orders=> Orders.Orders)
                .WithOne(ApplicationUser => ApplicationUser.User).OnDelete(DeleteBehavior.NoAction);
            #endregion Application User
            #region Role Permission
            builder.Entity<RolePermission>().HasOne(Role => Role.Role).
                WithMany(Permissions => Permissions.Permissions).OnDelete(DeleteBehavior.Cascade);
            #endregion Role Permission
            #region Order
            builder.Entity<Order>().Property(p => p.CurrencyPrice).HasColumnType("decimal(18,4)");
            builder.Entity<Order>().Property(p => p.InstantPrice).HasColumnType("decimal(18,4)");
            #endregion Order
            #endregion DbLogigs
        }
        #region Add DbSets
        public virtual DbSet<RolePermission> RolePermissions { get; set; }
        public virtual DbSet<Currency> Currencies { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<CurrencyChange> CurrencyChanges { get; set; }
        #endregion Add DbSets
    }
}
