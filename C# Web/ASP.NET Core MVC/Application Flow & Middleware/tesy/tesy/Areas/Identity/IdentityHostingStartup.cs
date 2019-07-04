using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using tesy.Models;

[assembly: HostingStartup(typeof(tesy.Areas.Identity.IdentityHostingStartup))]
namespace tesy.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<tesyContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("tesyContextConnection")));

                services.AddDefaultIdentity<IdentityUser>()
                    .AddEntityFrameworkStores<tesyContext>();
            });
        }
    }
}