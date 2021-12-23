using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using InventoryManagementApp.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using InventoryManagementApp.Service;
using InventoryManagementApp.Data.Models;
using Microsoft.Extensions.FileProviders;
using System.IO;

namespace InventoryManagementApp
{
    public class Startup
    {
        
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews().AddRazorRuntimeCompilation(); 
            services.AddControllersWithViews();

            services.AddDbContext<InventoryManagementContext>(options => 
                options.UseSqlServer(Configuration.GetConnectionString("SQL")));

            services.AddTransient<EFConnector, EFConnector>(); 
            services.AddTransient<InventoryService, InventoryService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();
            //// using Microsoft.Extensions.FileProviders;
            //// using System.IO;
            //app.UseStaticFiles(new StaticFileOptions
            //{
            //    FileProvider = new PhysicalFileProvider(
            //        Path.Combine(env.ContentRootPath, "Images")),
            //    RequestPath = "/Images"
            //});

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                app.UseEndpoints(endpoints => {
                    endpoints.MapControllerRoute(
                        name: "default",
                        pattern: "{controller=TakeInventory}/{action=Index}/{id?}");
                });
                
                //endpoints.MapGet("/", async context => //we define a pattern of route 
                //{
                //    await context.Response.WriteAsync("Hello World!");
                //});
            });
        }
    }
}
