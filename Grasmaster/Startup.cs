using Grasmaster.Infrastructure.Context;
using Grasmaster.Infrastructure.Services;
using Grasmaster.Infrastructure.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace at.mausa.grasmaste.frontend
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

            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IProductService, ProductService>();

            //services.ConfigureSqLite("Data Source=TestAdministrator.db");
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

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });

            WebApplicationBuilder builder = WebApplication.CreateBuilder();

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            //Add dbContext
            string connString = builder.Configuration.GetConnectionString("MainConn");
            builder.Services.AddDbContext<ApplicationDbContext>(options => {
                options.UseSqlite("Data Source=GrasmasterDB.db;");
            });
            WebApplication app1 = builder.Build();

            IServiceScope scope = app1.Services.CreateScope() ?? throw new NullReferenceException();

            ApplicationDbContext dbcontext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

            dbcontext.Database.EnsureDeleted();
            dbcontext.Database.EnsureCreated();

            // Configure the HTTP request pipeline.
            if (!app1.Environment.IsDevelopment())
            {
                app1.UseExceptionHandler("/Home/Error");
                app1.UseHsts();
            }

            app1.UseHttpsRedirection();
            app1.UseStaticFiles();

            app1.UseRouting();

            app1.UseAuthorization();

            app1.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}"
                );

            app1.Run();
        }
    }
}

