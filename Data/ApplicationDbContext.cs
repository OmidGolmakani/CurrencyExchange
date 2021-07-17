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
            #region Application User
            builder.Entity<ApplicationUser>().HasData(new ApplicationUser()
            {
                Id = 1,
                UserName = "Admin",
                NormalizedUserName = "ADMIN",
                PasswordHash = "AQAAAAEAACcQAAAAENSkzWsQZKhTh+7aBZLEAWRHo8O3XC0qp1d1RFJEdvxKt3rGy+8Agyt38iYrVR5Zyw==",
                SecurityStamp = "JF5Z6SA4QDPB246AF2WKXR5B5QAMMN7O",
                ConcurrencyStamp = "b4c38214-364e-4c16-9028-a2d7448435b1",
                PhoneNumber = "09150000000",
                PhoneNumberConfirmed = true,
                TwoFactorEnabled = false,
                LockoutEnabled = false,
                AccessFailedCount = 0,
                Name = "Admin",
                Family = "Admin",
                NationalCodeConfirmed = false,
                TelConfirmed = false
            }, new ApplicationUser()
            {
                Id = 2,
                UserName = "User1",
                NormalizedUserName = "USER1",
                PasswordHash = "AQAAAAEAACcQAAAAEEntwM294Ph6cmevAy6Q4LHVkhEEQC9Tqurw0jnG+J55aF0s2Ppsz4MRbR7ker9A8w==",
                SecurityStamp = "UC7D6KUHK3PXCOTP2CGX6L7IMP4TFWKM",
                ConcurrencyStamp = "8826450d-66b7-4a10-880a-cbad5790e841",
                PhoneNumber = "09150000000",
                PhoneNumberConfirmed = true,
                TwoFactorEnabled = false,
                LockoutEnabled = false,
                AccessFailedCount = 0,
                Name = "Admin",
                Family = "Admin",
                NationalCodeConfirmed = false,
                TelConfirmed = false
            });
            #endregion Application User
            #region Application Role
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
            #region Application User Role
            builder.Entity<ApplicationUserRole>().HasData(
                new ApplicationUserRole()
                {
                    RoleId = 1,
                    UserId = 1
                },
                new ApplicationUserRole()
                {
                    RoleId = 2,
                    UserId = 2
                });
            #endregion Application User Role
            #region Auth Items
            builder.Entity<AuthItem>().HasData(new AuthItem()
            {
                Id = 1,
                AuthName = "تصویر کاربر",
                AuthTypeId = (byte)Models.Enum.AuthItems.AuthTypeId.UserPicture,
                CreateDate = DateTime.Now,
                Deleted = false,
                Order = 1,
                Required = true,
                Description = "با استفاده از این احراز تصویر کاربر احراز می گردد"

            },
            new AuthItem()
            {
                Id = 2,
                AuthName = "کارت بانکی",
                AuthTypeId = (byte)Models.Enum.AuthItems.AuthTypeId.BankCard,
                CreateDate = DateTime.Now,
                Deleted = false,
                Order = 2,
                Required = true,
                Description = "احراز کارت بانکی"

            },
            new AuthItem()
            {
                Id = 3,
                AuthName = "کد ملی",
                AuthTypeId = (byte)Models.Enum.AuthItems.AuthTypeId.NationalCard,
                CreateDate = DateTime.Now,
                Deleted = false,
                Order = 3,
                Required = true,
                Description = "از طریق این احراز اطلاعات هویتی کاربر از طریق کارت ملی احراز می گردد"

            },
            new AuthItem()
            {
                Id = 4,
                AuthName = "تلفن ثابت",
                AuthTypeId = (byte)Models.Enum.AuthItems.AuthTypeId.Tel,
                CreateDate = DateTime.Now,
                Deleted = false,
                Order = 4,
                Required = true,
                Description = "احراز تلفن ثابت"

            });
            #endregion Auth Items
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
