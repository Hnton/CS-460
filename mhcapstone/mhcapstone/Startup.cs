using mhcapstone.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mhcapstone
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        //private string GetHerokuConnectionString()
        //{
        //    // Get the connection string from the ENV variables
        //    string connectionUrl = Environment.GetEnvironmentVariable("DATABASE_URL");

        //    // parse the connection string
        //    var databaseUri = new Uri(connectionUrl);

        //    string db = databaseUri.LocalPath.TrimStart('/');
        //    string[] userInfo = databaseUri.UserInfo.Split(':', StringSplitOptions.RemoveEmptyEntries);

        //    return $"User ID={userInfo[0]};Password={userInfo[1]};Host={databaseUri.Host};Port={databaseUri.Port};Database={db};Pooling=true;SSL Mode=Require;Trust Server Certificate=True;";
        //}

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //string connectionString = null;

            //string envVar = Environment.GetEnvironmentVariable("DATABASE_URL");
            //string postgresqlString = new Uri(envVar);

            //var uri = new Uri(envVar);
            //var username = uri.UserInfo.Split(':')[0];
            //var password = uri.UserInfo.Split(':')[1];
            //connectionString =
            //"; Database=" + uri.AbsolutePath.Substring(1) +
            //"; Username=" + username +
            //"; Password=" + password +
            //"; Port=" + uri.Port +
            //"; SSL Mode=Require; Trust Server Certificate=true;";


            



            //User ID=hnezeawjjrpeet;Password=7e3c1ae0ac5edf314ece5d7c5cfcce3675829a70cbd2998a09efb539427ba543;Host=ec2-3-221-243-122.compute-1.amazonaws.com;Port=5432;Database=df8m2b09hgjbq8;Pooling=true;SSL Mode=Require;Trust Server Certificate=True;"

            //postgres://hnezeawjjrpeet:7e3c1ae0ac5edf314ece5d7c5cfcce3675829a70cbd2998a09efb539427ba543@ec2-3-221-243-122.compute-1.amazonaws.com:5432/df8m2b09hgjbq8

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseNpgsql(
                    Configuration.GetConnectionString("DefaultConnection")));
            services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<ApplicationDbContext>();
            services.AddControllersWithViews();
            services.AddRazorPages();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
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
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
        }
    }
}
