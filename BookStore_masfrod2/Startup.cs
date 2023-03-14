// Mason Frodsham masfrod2
// Mission 9 

using BookStore_masfrod2.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore_masfrod2
{
    public class Startup
    {

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940

        public IConfiguration Configuration { get; set; }

        public Startup (IConfiguration temp)
        {
            Configuration = temp;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();

            services.AddDbContext<BookstoreContext>(options =>
            {
                options.UseSqlite(Configuration["ConnectionStrings:BookstoreDbConnection"]);
            });

            // enable repositories for the booklist and purchases models
            services.AddScoped<IBookstoreRepository, EFBookstoreRepository>();
            services.AddScoped<IPurchaseRepository, EFPurchaseRepository>();

            // enable razoer pages to be displayed
            services.AddRazorPages();

            services.AddDistributedMemoryCache();

            // session control
            services.AddSession();

            services.AddScoped<Cart>(x => SessionCart.GetCart(x));
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // corresponds to wwwroot 
            app.UseStaticFiles();

            app.UseSession();

            app.UseRouting();

            // create more user friendly endpoints
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute("typepage",
                    "{category}/Page{productPage}",
                    new { Controller = "Home", action = "Index" });

                endpoints.MapControllerRoute("Paging",
                    "Page{productPage}",
                    new { Controller = "Home", action = "Index", productPage = 1 });

                endpoints.MapControllerRoute("type",
                    "{category}",
                    new { Controller = "Home", action = "Index", productPage = 1 });
                

                endpoints.MapDefaultControllerRoute();

                endpoints.MapRazorPages();
            });   
        }
    }
}
