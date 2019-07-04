using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using twst.Data;
using twst.Models;

[assembly: HostingStartup(typeof(twst.Areas.Identity.IdentityHostingStartup))]
namespace twst.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {


            builder.ConfigureServices((context, services) => {
                services.AddDbContext<twstContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("twstContextConnection")));

                services.AddDefaultIdentity<IdentityUser>(config =>
                {
                    config.SignIn.RequireConfirmedEmail = true;
                }).AddEntityFrameworkStores<ApplicationDbContext>();
                services.AddDefaultIdentity<IdentityUser>()
                    .AddEntityFrameworkStores<twstContext>();

            });
        }
    }
}