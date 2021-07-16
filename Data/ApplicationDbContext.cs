﻿using CurrencyExchange.Models.Entity;
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
            builder.Entity<Currency>().Property(p => p.PurchasePrice).HasColumnType("decimal(18,4)");
            builder.Entity<Currency>().Property(p => p.SalesPrice).HasColumnType("decimal(18,4)");
            //Order
            builder.Entity<Currency>().HasMany(Orders => Orders.Orders)
                .WithOne(Currency => Currency.Currency).OnDelete(DeleteBehavior.NoAction);
            //Buy
            builder.Entity<Currency>().HasMany(Trades => Trades.Trades);
            //Currency Change
            builder.Entity<Currency>().HasMany(CurrencyChanges => CurrencyChanges.CurrencyChanges)
                .WithOne(Currency => Currency.Currency).OnDelete(DeleteBehavior.Cascade);
            #endregion Currency
            #region Currency Change
            builder.Entity<CurrencyChange>().Property(p => p.PurchasePrice).HasColumnType("decimal(18,4)");
            builder.Entity<CurrencyChange>().Property(p => p.SalesPrice).HasColumnType("decimal(18,4)");
            builder.Entity<CurrencyChange>().HasIndex(p => new { p.LastChangeDate }).IsUnique();
            #endregion Currency Change
            #region Application User
            ///Order
            builder.Entity<ApplicationUser>().HasMany(Orders => Orders.Orders)
                .WithOne(ApplicationUser => ApplicationUser.OrderUser).OnDelete(DeleteBehavior.NoAction);
            ///Trades
            builder.Entity<ApplicationUser>().HasMany(Trades => Trades.Trades);
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
            #endregion Trades
            #region AuthItem
            builder.Entity<AuthItem>().HasIndex(x => x.Order).IsUnique();
            #endregion AuthItem
            #region AuthUserItem
            builder.Entity<AuthUserItem>().HasIndex(x => new { x.UserId, x.AuthItemId, x.Deleted }).IsUnique();
            builder.Entity<AuthUserItem>().HasOne(Admin => Admin.AdminUser).WithMany(AuthUserItems => AuthUserItems.AuthUserItems);
            #endregion AuthUserItem
            #endregion DbLogigs
            #region Seed
            #region Application User Role
            builder.Entity<ApplicationRole>().HasData(new ApplicationRole()
            {
                Id = 1,
                Name = "Administrator",
                NormalizedName = "ADMINISTRATOR",
                ConcurrencyStamp = "420d99de-7b2d-4a31-acd9-da52b0927bd0",
            }, new ApplicationRole()
            {
                Id = 2,
                Name = "User",
                NormalizedName = "USER",
                ConcurrencyStamp = "47a274bd-9ea4-4475-a931-00ea4a3e86f7",
            });
            #endregion Application User Role
            #endregion Seed
        }
        #region Add DbSets
        public virtual DbSet<RolePermission> RolePermissions { get; set; }
        public virtual DbSet<Currency> Currencies { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Trades> Trades { get; set; }
        public virtual DbSet<CurrencyChange> CurrencyChanges { get; set; }
        public virtual DbSet<Image> Images { get; set; }
        public virtual DbSet<ErrorLog> ErrorLogs { get; set; }
        public virtual DbSet<AuthItem> AuthItems { get; set; }
        public virtual DbSet<AuthUserItem> AuthUserItems { get; set; }


        #endregion Add DbSets
    }
}
