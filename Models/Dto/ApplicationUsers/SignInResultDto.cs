using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyExchange.Models.Dto.ApplicationUsers
{
    public class SignInResultDto
    {
        public long UserId { get; set; }
        public SignInResult SignIn { get; set; }
        public double ExprireDate { get; set; }
        public string Token { get; set; }
        public bool IsAdmin { get; set; }
        public byte AuthUserStatusId { get; set; }
        public string AuthUserStatus { get { return Helper.AuthUserItemFunc.GetStatus(this.AuthUserStatusId); } }
    }
}
