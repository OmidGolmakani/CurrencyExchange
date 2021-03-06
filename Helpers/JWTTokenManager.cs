using CurrencyExchange.AppSettings.Dto.Authentications;
using CurrencyExchange.CustomException;
using CurrencyExchange.Data;
using CurrencyExchange.Helpers;
using CurrencyExchange.Models.Entity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Logging;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace CurrencyExchange.Helpers
{
    public class JWTTokenManager
    {
        internal static IConfiguration configuration = null;
        private static AuthenticationDto AuthInfo
        {
            get
            {
                AuthenticationDto authorizationOption = new AuthenticationDto();
                configuration.GetSection("Authentication").Bind(authorizationOption);
                return authorizationOption;
            }
        }
        internal static string GeneratePermissionToken(RolePermission Permission,
                                                       ApplicationDbContext dbContext)
        {

            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            ClaimsIdentity claims = new ClaimsIdentity();
            var key = Encoding.BigEndianUnicode.GetBytes(AuthInfo.SecretKey);
            var SecurityKey = new SymmetricSecurityKey(key);
            IdentityModelEventSource.ShowPII = true;

            claims.AddClaim(new Claim(ClaimTypes.Role, Permission.RoleId.ToString()));
            claims.AddClaim(new Claim("Url", Permission.Url));

            SecurityTokenDescriptor TokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = claims,
                SigningCredentials = new SigningCredentials(SecurityKey, SecurityAlgorithms.HmacSha256Signature),
            };
            SecurityToken token = tokenHandler.CreateToken(TokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
        internal static Tuple<string, double> GenerateToken(string username, ApplicationDbContext dbContext)
        {
            var _User = dbContext.Users.FirstOrDefault(x => x.UserName == username);
            if (_User == null)
            {
                throw new MyException("کاربر مورد نظر یافت نشد");
            }
            var _Roles = (from ru in dbContext.UserRoles
                          join r in dbContext.Roles
                          on ru.RoleId equals r.Id
                          where ru.UserId == _User.Id
                          select new
                          {
                              RoleName = r.Name
                          }).ToList();

            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            ClaimsIdentity claims = new ClaimsIdentity();
            var key = Encoding.BigEndianUnicode.GetBytes(AuthInfo.SecretKey);
            var SecurityKey = new SymmetricSecurityKey(key);
            IdentityModelEventSource.ShowPII = true;

            claims.AddClaim(new Claim(ClaimTypes.NameIdentifier, _User.Id.ToString()));
            claims.AddClaim(new Claim(ClaimTypes.Name, _User.UserName));
            claims.AddClaim(new Claim(ClaimTypes.MobilePhone, _User.PhoneNumber));
            claims.AddClaim(new Claim(ClaimTypes.Email, _User.Email ?? ""));
            claims.AddClaim(new Claim(ClaimTypes.Expired, DateTime.Now.AddMinutes(AuthInfo.ExpiryTime).ToString()));
            claims.AddClaim(new Claim(ClaimTypes.Role, string.Join(string.Empty, _Roles.Select(x => x.RoleName).ToArray())));

            SecurityTokenDescriptor TokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = claims,
                Expires = DateTime.Now.AddMinutes(AuthInfo.ExpiryTime),
                SigningCredentials = new SigningCredentials(SecurityKey, SecurityAlgorithms.HmacSha256Signature),
                NotBefore = DateTime.Now
            };
            SecurityToken token = tokenHandler.CreateToken(TokenDescriptor);
            double TotalMilliseconds = Math.Round((DateTime.Now.AddMinutes(AuthInfo.ExpiryTime) - DateTime.Now).TotalMilliseconds, 0);
            return new Tuple<string, double>(tokenHandler.WriteToken(token), TotalMilliseconds);
        }
        internal static ClaimsPrincipal GetPrincipal(string token)
        {
            try
            {
                JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
                JwtSecurityToken jwtToken = (JwtSecurityToken)tokenHandler.ReadToken(token);
                if (jwtToken == null)
                    return null;
                byte[] key = Encoding.BigEndianUnicode.GetBytes(AuthInfo.SecretKey);
                TokenValidationParameters parameters = new TokenValidationParameters()
                {
                    RequireExpirationTime = true,
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    IssuerSigningKey = new SymmetricSecurityKey(key)
                };
                SecurityToken securityToken;
                ClaimsPrincipal principal = tokenHandler.ValidateToken(token, parameters, out securityToken);
                return principal;
            }
            catch (Exception)
            {
                return null;
            }
        }
        internal static ClaimsPrincipal GetPermissionPrincipal(string token)
        {
            try
            {
                JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
                JwtSecurityToken jwtToken = (JwtSecurityToken)tokenHandler.ReadToken(token);
                if (jwtToken == null)
                    return null;
                byte[] key = Encoding.BigEndianUnicode.GetBytes(AuthInfo.SecretKey);
                TokenValidationParameters parameters = new TokenValidationParameters()
                {
                    RequireExpirationTime = false,
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    IssuerSigningKey = new SymmetricSecurityKey(key)
                };
                SecurityToken securityToken;
                ClaimsPrincipal principal = tokenHandler.ValidateToken(token, parameters, out securityToken);
                return principal;
            }
            catch (Exception)
            {
                return null;
            }
        }
        internal static string ValidatePermissionToken(string Token)
        {
            try
            {
                ClaimsPrincipal principal = GetPermissionPrincipal(Token);
                if (principal == null)
                    return null;
                ClaimsIdentity identity = null;
                try
                {
                    identity = (ClaimsIdentity)principal.Identity;
                }
                catch (NullReferenceException)
                {
                    return null;
                }


                Claim usernameClaim = identity.FindFirst("Url");
                return usernameClaim.Value;
            }
            catch (MyException ex)
            {
                throw new MyException("ValidatePermissionToken", ex);
            }
        }
        internal static string ValidateToken(string token, ApplicationDbContext _dbContext)
        {
            try
            {
                string username = null;
                ClaimsPrincipal principal = GetPrincipal(token);
                if (principal == null)
                    return null;
                ClaimsIdentity identity = null;
                try
                {
                    identity = (ClaimsIdentity)principal.Identity;
                }
                catch (NullReferenceException)
                {
                    return null;
                }
                long Id = identity.FindFirst(ClaimTypes.NameIdentifier).Value.ToLong();
                string UserName = identity.FindFirst(ClaimTypes.Name).Value;
                string Phone = identity.FindFirst(ClaimTypes.MobilePhone).Value;
                string Email = identity.FindFirst(ClaimTypes.Email).Value;
                var User = _dbContext.Users.FirstOrDefault(x =>
                                                           x.Id == Id &&
                                                           x.UserName == UserName &&
                                                           x.PhoneNumber == Phone &&
                                                           x.Email == (Email != "" ? Email : null));
                if (User == null)
                {
                    throw new Exception("توکن ارسال شده نامعتبر است");
                }


                Claim usernameClaim = identity.FindFirst(ClaimTypes.Name);
                username = usernameClaim.Value;
                return username;
            }
            catch (MyException ex)
            {
                throw new MyException("ValidateToken", ex);
            }
        }
        internal static long GetUserIdByToken(string token)
        {
            try
            {
                ClaimsPrincipal principal = GetPrincipal(token);
                if (principal == null)
                    return 0;
                ClaimsIdentity identity = null;
                try
                {
                    identity = (ClaimsIdentity)principal.Identity;
                }
                catch (NullReferenceException)
                {
                    return 0;
                }
                return identity.FindFirst(ClaimTypes.NameIdentifier).Value.ToLong();

            }
            catch (MyException ex)
            {
                throw ex;
            }
        }
        internal static string GetTokenFromRequest()
        {
            if (Helpers.AppContext.Current.Request.Headers.
                   FirstOrDefault(x => x.Key == "Authorization").Value.FirstOrDefault() == null)
            {
                throw new MyException("توکن ارسال نشده است");
            }
            var Token = Helpers.AppContext.Current.Request.Headers.
                FirstOrDefault(x => x.Key == "Authorization").Value.FirstOrDefault().
                Replace("Bearer", "").Trim();
            return Token;
        }
    }
}
