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
            //Order
            builder.Entity<Currency>().HasMany(Orders => Orders.Orders)
                .WithOne(Currency => Currency.Currency).OnDelete(DeleteBehavior.NoAction);
            //Buy
            builder.Entity<Currency>().HasMany(Trades => Trades.Trades)
                .WithOne(Currency => Currency.Currency).OnDelete(DeleteBehavior.NoAction);
            //Currency Change
            builder.Entity<Currency>().HasMany(CurrencyChanges => CurrencyChanges.CurrencyChanges)
                .WithOne(Currency => Currency.Currency).OnDelete(DeleteBehavior.Cascade);
            #endregion Currency
            #region Currency Change
            builder.Entity<CurrencyChange>().Property(p => p.BuyPrice).HasColumnType("decimal(18,4)");
            builder.Entity<CurrencyChange>().Property(p => p.SalePrice).HasColumnType("decimal(18,4)");
            builder.Entity<CurrencyChange>().HasIndex(p => new { p.LastChangeDate, p.LastChangeTime }).IsUnique();
            #endregion Currency Change
            #region Application User
            ///Order
            builder.Entity<ApplicationUser>().HasMany(Orders => Orders.Orders)
                .WithOne(ApplicationUser => ApplicationUser.OrderUser).OnDelete(DeleteBehavior.NoAction);
            ///Trades
            builder.Entity<ApplicationUser>().HasMany(Trades => Trades.Trades)
                .WithOne(ApplicationUser => ApplicationUser.TradesUser).OnDelete(DeleteBehavior.NoAction);
            ///BankAccount
            builder.Entity<ApplicationUser>().HasMany(BankAccounts => BankAccounts.BankAccounts)
                .WithOne(ApplicationUser => ApplicationUser.User).OnDelete(DeleteBehavior.NoAction);
            //Image
            builder.Entity<ApplicationUser>().HasMany(Images => Images.Images)
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
            #region Trades
            builder.Entity<Trades>().Property(p => p.CurrencyPrice).HasColumnType("decimal(18,4)");
            builder.Entity<Trades>().Property(p => p.InstantPrice).HasColumnType("decimal(18,4)");
            #endregion Trades
            #endregion DbLogigs
        }
        #region Add DbSets
        public virtual DbSet<RolePermission> RolePermissions { get; set; }
        public virtual DbSet<Currency> Currencies { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Trades> Trades { get; set; }
        public virtual DbSet<CurrencyChange> CurrencyChanges { get; set; }
        public virtual DbSet<Image> Images { get; set; }
        #endregion Add DbSets
    }
}
