using CurrencyExchange.Configs.Servises.Extentions;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Identity.Web;
using Microsoft.Identity.Web.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CurrencyExchange
{
    public class Startup
    {
        public IConfiguration _configuration { get; }
        public IWebHostEnvironment _env { get; }
        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            this._configuration = configuration;
            this._env = env;
            //Helper.JWTTokenManager.configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddMyDbContext(_configuration);
            //services.AddMyIdentity();
            //services.AddHttpContextAccessor();
            //services.AddScopeds();
            //services.AutoMapperConfig();
            //services.AddRazorPages();
            //services.AddControllers();
            //services.AddAuthentication();
            ////services.AddAuthentication(OpenIdConnectDefaults.AuthenticationScheme)
            ////    .AddMicrosoftIdentityWebApp(Configuration.GetSection("AzureAd"));

            //services.AddControllersWithViews(options =>
            //{
            //    var policy = new AuthorizationPolicyBuilder()
            //        .RequireAuthenticatedUser()
            //        .Build();
            //    options.Filters.Add(new AuthorizeFilter(policy));
            //});
            //services.AddRazorPages()
            //     .AddMicrosoftIdentityUI();

            services.AddMyDbContext(_configuration);
            services.AddMyIdentity();
            services.AddHttpContextAccessor();
            services.AddScopeds();
            services.AutoMapperConfig();
            services.AddRazorPages();
            services.AddControllers();
            services.AddSwagger(_env);

            services.FluentValidationConfig();
            services.AppSettings(_configuration);
            services.AddCors(o => o.AddPolicy("MyCorsPolicy", builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            }));

            services.AddMyAuthorization(_configuration);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                //app.ConfigureExceptionHandler(logger);

            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();
            app.UseSwagger();



            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Spad API V1");
                c.RoutePrefix = string.Empty;
            });
            app.UseCors("MyCorsPolicy");
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
                endpoints.MapControllers();
                endpoints.MapAreaControllerRoute(
                    "Membership",
                    "Membership",
                    "Membership/{controller=Account}/{action=Index}"
                    );
            });

        }
    }
}
