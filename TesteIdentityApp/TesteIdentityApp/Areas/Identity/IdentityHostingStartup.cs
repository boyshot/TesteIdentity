using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TesteIdentityApp.Areas.Identity.Data;
using TesteIdentityApp.Identity;

[assembly: HostingStartup(typeof(TesteIdentityApp.Areas.Identity.IdentityHostingStartup))]
namespace TesteIdentityApp.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<IdentityAppContext>(options =>
                    options.UseSqlite(
                        context.Configuration.GetConnectionString("IdentityAppContextConnection")));

                services.AddDefaultIdentity<IdentityUser>()
                    .AddEntityFrameworkStores<IdentityAppContext>();
            });
        }
    }
}