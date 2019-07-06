using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Eventures.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Eventures.Domain;
using Eventures.Extensions;
using Eventures.Data.Seeding;
using Eventures.ModelBinders;

namespace Eventures
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
            services.AddDbContext<EventureDbContext>(options =>
                options.UseSqlServer(this.Configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<EventureUserRoleSeeder>();
            services.AddScoped<EventureAdminUserSeeder>();

            services.AddIdentity<EventuresUser, IdentityRole>()
                .AddEntityFrameworkStores<EventureDbContext>()  
                .AddDefaultTokenProviders();

            services.Configure<IdentityOptions>(options =>
            {
              //// Password settings.
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

            services.AddMvc(options =>
            {
               // options.ModelBinderProviders.Insert(0, new DateTimeToYearModelBinderProvider());
                options.Filters.Add(new AutoValidateAntiforgeryTokenAttribute());
            }).SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            //Create DB
            app.UseDatabaseSeeding();

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
