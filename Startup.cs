using Microsoft.AspNetCore.Identity;
using System.Reflection;
using System;
using СorporateRideManagementSystem.Data;
using Microsoft.EntityFrameworkCore;
using FoodDiary.Data.Entities;

namespace СorporateRideManagementSystem
{
    public class Startup
    {
        private readonly IConfiguration config;

        public Startup(IConfiguration config)
        {
            this.config = config;
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();

            services.AddControllersWithViews().AddRazorRuntimeCompilation();
            services.AddDbContext<MyDbContext>(options => options.UseSqlServer(config["ConnectionStrings:MyAppContextDb"]));
            services.AddControllers(options => options.SuppressImplicitRequiredAttributeForNonNullableReferenceTypes = true);

            services.AddIdentity<Employee, IdentityRole>(cfg =>
            {
                cfg.User.RequireUniqueEmail = true;
                cfg.Password.RequireDigit = false;
                cfg.Password.RequireNonAlphanumeric = false;

            }).AddEntityFrameworkStores<MyDbContext>();

        }


        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }


            app.UseStaticFiles();           

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(cfg =>
            {
                cfg.MapRazorPages();
                cfg.MapControllerRoute("Default",
                    "/{controller}/{action}/{id?}",
                    new { controller = "App", action = "Index" });
            });
        }
    }
}
