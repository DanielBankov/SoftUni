using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Panda.Data;
using Panda.Domain;

namespace Panda
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


            services.AddDbContext<PandaDbContext>(options =>
                options.UseSqlServer(this.Configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentity<PandaUser, PandaUserRole>()
                .AddEntityFrameworkStores<PandaDbContext>()
                .AddDefaultTokenProviders();

            services.Configure<IdentityOptions>(options =>
            {
                // Password settings.
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 3;
                options.Password.RequiredUniqueChars = 0;

                // Lockout settings.
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.AllowedForNewUsers = true;

                // User settings.
                options.User.AllowedUserNameCharacters =
                "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
                options.User.RequireUniqueEmail = true;
            });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            //Create DB
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                using (var context = serviceScope.ServiceProvider.GetRequiredService<PandaDbContext>())
                {
                    context.Database.Migrate();

                    //This should be with IRolesSeeder with void Seed()
                    if (!context.Roles.Any())
                    {
                        context.Roles.Add(new PandaUserRole { Name = "Admin", NormalizedName = "ADMIN" });
                        context.Roles.Add(new PandaUserRole { Name = "User", NormalizedName = "USER" });
                    }

                    //This should be with IPackageStatusesSeeder with void Seed()
                    if (!context.PackageStatuses.Any())
                    {
                        context.PackageStatuses.Add(new PackageStatus { Name = "Pending" });
                        context.PackageStatuses.Add(new PackageStatus { Name = "Shipped" });
                        context.PackageStatuses.Add(new PackageStatus { Name = "Delivered" });
                        context.PackageStatuses.Add(new PackageStatus { Name = "Acquired" });
                    }

                    context.SaveChanges();
                }
            }

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseAuthentication();

            app.UseMvcWithDefaultRoute();
        }
    }
}
