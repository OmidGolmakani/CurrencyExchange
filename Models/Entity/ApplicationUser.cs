using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
            Trades = new HashSet<Trades>();
            BankAccounts = new HashSet<BankAccount>();
            Images = new HashSet<Image>();
            AuthUserItems = new HashSet<AuthUserItem>();
            ApplicationUserRoles = new HashSet<ApplicationUserRole>();
        }
        [MaxLength(100)]
        public override string SecurityStamp { get => base.SecurityStamp; set => base.SecurityStamp = value; }
        [MaxLength(100)]
        public override string ConcurrencyStamp { get => base.ConcurrencyStamp; set => base.ConcurrencyStamp = value; }
        [MaxLength(60)]
        public override string UserName { get => base.UserName; set => base.UserName = value; }
        [MaxLength(200)]
        public override string PasswordHash { get => base.PasswordHash; set => base.PasswordHash = value; }
        [MaxLength(60)]
        public override string NormalizedUserName { get => base.NormalizedUserName; set => base.NormalizedUserName = value; }
        [MaxLength(50)]
        public override string NormalizedEmail { get => base.NormalizedEmail; set => base.NormalizedEmail = value; }
        [MaxLength(12)]
        public override string PhoneNumber { get => base.PhoneNumber; set => base.PhoneNumber = value; }
        [MaxLength(50)]
        public override string Email { get => base.Email; set => base.Email = value; }
        [StringLength(60)]
        public string Name { get; set; }
        [StringLength(60)]
        public string Family { get; set; }
        [StringLength(10)]
        public string NationalCode { get; set; }
        [DefaultValue(false)]
        public bool NationalCodeConfirmed { get; set; }
        [StringLength(13)]
        public string Tel { get; set; }
        [DefaultValue(false)]
        public bool TelConfirmed { get; set; }
        [MaxLength(200)]
        public string Address { get; set; }
        [MaxLength(10)]
        public string PostalCode { get; set; }
        [MaxLength(500)]
        public string Description { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<Trades> Trades { get; set; }
        public virtual ICollection<Image> Images { get; set; }
        public virtual ICollection<BankAccount> BankAccounts { get; set; }
        public virtual ICollection<AuthUserItem> AuthUserItems { get; set; }
        public virtual ICollection<ApplicationUserRole> ApplicationUserRoles { get; set; }





    }
}
