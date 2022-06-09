using _0_Framework.Contract;
using _0_Framework.Utilities;
using _0_Framework.Utilities.ZarinPal;
using _01_Framework.Application;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ServiceHost.Uploder;
using System;

namespace ServiceHost
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews().AddRazorRuntimeCompilation();
            services.AddHttpContextAccessor();

            var connectionstring = Configuration.GetConnectionString("MyNiaSmart");
            AccountManagement.Configuration.AccountManagementBootstrapper.Configure(services, connectionstring);
            ShopManagement.Configuration.ShopManagementBootstrapper.Configure(services, connectionstring);

            //Framework Configuration
            services.AddTransient<IFileUploader,FileUploader>();
            services.AddTransient<IAuthHelper,AuthHelper>();
            services.AddTransient<IZarinPalFactory,ZarinPalFactory>();

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;

            }).AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, o =>
               {
                   o.LoginPath = new PathString("/Account/RegisterOrLogin");
                   o.LogoutPath = new PathString("/Account/LogOut");
                   o.ExpireTimeSpan = TimeSpan.FromMinutes(43200);
                   o.AccessDeniedPath = new PathString("/AccessDenied");
               });


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseAuthentication();

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseRouting();

            app.UseAuthorization();



            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");

                endpoints.MapAreaControllerRoute(
                    name: "Administrator",
                    areaName: "Administrator",
                    pattern: "{area:exists}/{controller=Home}/{action=index}/{id?}");
            });

        }
    }
}
