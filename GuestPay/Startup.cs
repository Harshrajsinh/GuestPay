using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace GuestPay
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
            services.AddControllersWithViews();

            //if (Debugger.IsAttached)
            //{
            //    services.AddDataProtection().SetApplicationName("GuestPay").ProtectKeysWithDpapi(true)
            //        .PersistKeysToFileSystem(new DirectoryInfo(@"C:\core\keys"));
            //}
            //Session Management
            services.AddDistributedSqlServerCache(options =>
                {
                    options.ConnectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=GuestPay;Integrated Security=True";
                    options.SchemaName = "dbo";
                    options.TableName = "ASPStateTempSessions";
                }
            );

            services.AddSession(options =>
            {
                options.Cookie.Name = "guest_pay";
                options.IdleTimeout = TimeSpan.FromMinutes(15);
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
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


            //configuring to use the sessions
            app.UseSession();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=SubscriberDetails}/{id?}");
            });
        }
    }
}
