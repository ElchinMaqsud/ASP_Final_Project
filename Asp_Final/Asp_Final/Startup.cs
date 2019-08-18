using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Asp_Final.Db;
using Asp_Final.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Asp_Final
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
                services.Configure<CookiePolicyOptions>(options =>
                {
                    // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                    options.CheckConsentNeeded = context => true;
                    options.MinimumSameSitePolicy = SameSiteMode.None;
                });

                services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<Final_Db>()
                .AddDefaultUI()
                .AddDefaultTokenProviders();

                services.Configure<IdentityOptions>(identityOptions =>
                {
                    identityOptions.Password.RequireNonAlphanumeric = true;
                    identityOptions.Password.RequiredLength = 8;
                    identityOptions.Password.RequireDigit = true;
                    identityOptions.Password.RequireLowercase = true;
                    identityOptions.Password.RequireUppercase = true;

                    identityOptions.User.RequireUniqueEmail = true;

                    identityOptions.Lockout.MaxFailedAccessAttempts = 3;
                    identityOptions.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(10);
                    identityOptions.Lockout.AllowedForNewUsers = true;
                });

                services.AddDbContext<Final_Db>(options =>
                {
                    options.UseSqlServer(Configuration["ConnectionsStrings:Default"]);
                });

                services.AddMvc();
            }

            // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
            public void Configure(IApplicationBuilder app, IHostingEnvironment env)
            {
                if (env.IsDevelopment())
                {
                    app.UseDeveloperExceptionPage();
                }
                else
                {
                    app.UseExceptionHandler("/Home/Error");
                    app.UseHsts();
                }

                app.UseHttpsRedirection();
                app.UseStaticFiles();
                app.UseCookiePolicy();
                app.UseAuthentication();

                app.UseMvc(routes =>
                {   
                    routes.MapRoute(
                      name: "areas",
                      template: "{area:exists}/{controller=Dashboard}/{action=Indexi}/{id?}"
                    );
                });

                app.UseMvc(routes =>
                {
                    routes.MapRoute(
                        name: "default",
                        template: "{controller=Home}/{action=Index}/{id?}");
                });
            }
        }
    }

