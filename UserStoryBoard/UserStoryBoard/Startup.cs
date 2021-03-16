using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserStoryBoard.Interface;
using UserStoryBoard.Services;
using UserStoryBoard.Models;

namespace UserStoryBoard
{
    public class Startup
    {
        public Startup(IConfiguration configuration) {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services) {
            services.AddRazorPages();

            services.AddSingleton<IBoards, BoardService>();
            services.AddSingleton<UserService,UserService>();

            services.AddTransient<JsonFileService<Board>>();
            services.AddTransient<JsonFileService<User>>();

            // Login Options
            services.Configure<CookiePolicyOptions>(options => {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            }); services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(cookieOptions => {
                cookieOptions.LoginPath = "/Login/LoginPage";
            }); services.AddMvc().AddRazorPagesOptions(options => {
                options.Conventions.AuthorizeFolder("/4LevelsTests");
                options.Conventions.AuthorizeFolder("/Backlogs");
                options.Conventions.AuthorizeFolder("/Boards");
                options.Conventions.AuthorizeFolder("/CanvasModel");
                options.Conventions.AuthorizeFolder("/InceptionDecks");
                options.Conventions.AuthorizeFolder("/SwotAnalyse");
                options.Conventions.AuthorizeFolder("/TimeLine");
                options.Conventions.AuthorizeFolder("/UserStories");
            }).SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            //////////////////////////////////services.AddSingleton<UserService, UserService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env) {
            if (env.IsDevelopment()) {
                app.UseDeveloperExceptionPage();
            }
            else {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });
        }
    }
}
