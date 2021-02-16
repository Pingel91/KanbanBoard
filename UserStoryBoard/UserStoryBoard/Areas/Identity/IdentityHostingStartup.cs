using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using UserStoryBoard.Data;

[assembly: HostingStartup(typeof(UserStoryBoard.Areas.Identity.IdentityHostingStartup))]
namespace UserStoryBoard.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<UserStoryBoardContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("UserStoryBoardContextConnection")));

                services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddEntityFrameworkStores<UserStoryBoardContext>();
            });
        }
    }
}