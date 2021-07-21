﻿using CurrencyExchange.Models.Dto.ApplicationUsers;
using CurrencyExchange.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyExchange.Models.Helper
{
    internal static class ApplicationUserFunc
    {
        internal static string GetUserFullName(string Name, string Family)
        {
            return string.Format("{0} {1}", Name, Family).Trim();
        }
        internal static string GetUserFullName(this ApplicationUserDto x)
        {
            return GetUserFullName(x.Name, x.Family);
        }
        internal static string GetUserFullName(this Models.Entity.ApplicationUser x)
        {
            return GetUserFullName(x.Name, x.Family);
        }
        internal static string GetAuthStatus(this ApplicationUserDto x)
        {
            return Helper.AuthUserItemFunc.GetStatus((x.AuthStatusId ?? 2));
        }
        internal static string GetUserFullName(this Models.Dto.ApplicationUsers.ApplicationUserAuthDto x)
        {
            return GetUserFullName(x.Name, x.Family);
        }
        internal static IEnumerable<ApplicationUserDto> MapApplicationUser(IEnumerable<ApplicationUser> users,
                                                                           IEnumerable<ApplicationUserRole> userRoles,
                                                                           IEnumerable<ApplicationRole> roles,
                                                                           IEnumerable<AuthUserItem> auths)
        {
            return (from u in users
                    join ur in userRoles
                    on u.Id equals ur.UserId
                    join r in roles
                    on ur.RoleId equals r.Id


                    select new ApplicationUserDto()
                    {
                        AuthStatusId = auths.FirstOrDefault(x => x.UserId == u.Id) == null && r.Name != "Administrator" ?
                                       (byte)Enum.AuthUserItem.Status.Rejected : r.Name == "Administrator" ?
                                       (byte)Enum.AuthUserItem.Status.Accepted : auths.LastOrDefault(x => x.UserId == u.Id).Status,
                        ConcurrencyStamp = u.ConcurrencyStamp,
                        Email = u.Email,
                        Name = u.Name,
                        Family = u.Family,
                        RoleName =r.Name,
                        Id = u.Id,
                        IsAdmin = r.Name == "Administrator" ? true : false,
                        NationalCode = u.NationalCode,
                        NationalCodeConfirmed = u.NationalCodeConfirmed,
                        PhoneNumber = u.PhoneNumber,
                        SecurityStamp = u.SecurityStamp,
                        Tel = u.Tel,
                        TelConfirmed = u.TelConfirmed,
                        UserName = u.UserName
                    });
        }
    }
}
