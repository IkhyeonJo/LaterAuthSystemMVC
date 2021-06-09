using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MVCUI.Areas.Identity.Data;
using MVCUI.Data;

[assembly: HostingStartup(typeof(MVCUI.Areas.Identity.IdentityHostingStartup))]
namespace MVCUI.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                string connectionString = context.Configuration.GetConnectionString("AuthMVCDBContextConnection");
                services.AddDbContext<AuthMVCDBContext>(options =>
                options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

                services.AddDefaultIdentity<ApplicationUser>(options => {
                    options.SignIn.RequireConfirmedAccount = false;
                    options.Password.RequireLowercase = false;
                    options.Password.RequireUppercase = false;
                    })

                    .AddEntityFrameworkStores<AuthMVCDBContext>();
            });
        }
    }
}