using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyExchange.Configs.Servises.Extentions
{
    public static class Authentication
    {
        public static IServiceCollection AddMyAuthorization(this IServiceCollection services,
                                                            IConfiguration configuration)
        {
            AppSettings.Dto.Authentications.AuthenticationDto authorizationOption = new AppSettings.Dto.Authentications.AuthenticationDto();
            configuration.GetSection("Authentication").Bind(authorizationOption);

            services.AddAuthentication(configureOptions: option =>
            {
                option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(option =>
            {
                option.RequireHttpsMetadata = false;
                option.SaveToken = true;
                option.IncludeErrorDetails = true;
                var secretbyte = Encoding.BigEndianUnicode.GetBytes(authorizationOption.SecretKey);
                var key = new SymmetricSecurityKey(secretbyte);
                var tokenValidation = new TokenValidationParameters();
                tokenValidation.ValidateIssuer = false;
                tokenValidation.ValidateAudience = false;
                tokenValidation.ValidateIssuerSigningKey = true;
                tokenValidation.ValidIssuers = authorizationOption.ValidIssuers;
                tokenValidation.ValidAudience = authorizationOption.ValidAudience;
                tokenValidation.IssuerSigningKey = key;
                option.TokenValidationParameters = tokenValidation;
                option.Events = new JwtBearerEvents
                {
                    OnMessageReceived = context =>
                    {
                        context.Token = context.Request.Cookies["AccessToken"];
                        return Task.CompletedTask;
                    }
                    ,
                    OnAuthenticationFailed = context =>
                  {
                      if (context.Exception.GetType() == typeof(SecurityTokenExpiredException))
                      {
                          context.Response.Headers.Add("Token-Expired", "true");
                          context.NoResult();
                          context.Response.StatusCode = 500;
                          context.Response.ContentType = "text/plain";
                          context.Fail(context.Exception);
                      }
                      return Task.CompletedTask;
                  }
                };
            });
            services.PostConfigure<CookieAuthenticationOptions>(IdentityConstants.ApplicationScheme, option =>
            {
                option.Cookie.Name = "AccessToken";
                option.ExpireTimeSpan = TimeSpan.FromTicks(DateTime.Now.AddMinutes(authorizationOption.ExpiryTime).Ticks);
            });
            services.AddAuthorization(options =>
            options.AddPolicy("ValidAccessToken", policy =>
            {
                policy.AuthenticationSchemes.Add(JwtBearerDefaults.AuthenticationScheme);
                policy.RequireAuthenticatedUser();
            }));
            return services;
        }
    }
}
