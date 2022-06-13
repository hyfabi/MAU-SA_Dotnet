using At.Mausa.Grasmaster.Infrastructure.Context;
using At.Mausa.Grasmaster.Infrastructure.Services;
using At.Mausa.Grasmaster.Infrastructure.Services.Interfaces;

namespace At.Mausa.Grasmaster.Frontend; 
public class Startup {
	public Startup(IConfiguration configuration) {
		Configuration = configuration;
	}

	public IConfiguration Configuration { get; }

	// This method gets called by the runtime. Use this method to add services to the container.
	public void ConfigureServices(IServiceCollection services) {
		services.AddControllersWithViews();
		services.AddSqlite<ApplicationDbContext>("Data Source=TestAdministrator.db");
        services.AddTransient<IUserService, UserService>();
		services.AddTransient<IProductService, ProductService>();
		//services.AddTransient<ISeedingService,SeedingService>();


	}

	// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
	public void Configure(IApplicationBuilder app, IWebHostEnvironment env) {
		if(env.IsDevelopment()) {
			app.UseDeveloperExceptionPage();
		} else {
			app.UseExceptionHandler("/Home/Error");

			app.UseHsts();
		}
		app.UseHttpsRedirection()
		.UseStaticFiles()
		.UseRouting()
		.UseAuthorization()

		.UseEndpoints(endpoints => {
			endpoints.MapControllerRoute(
			name: "product",
			pattern: "{controller=product}/{action=Index}/{id?}"
            );

			endpoints.MapControllerRoute(
				name: "default",
				pattern: "{controller=home}/{action=Index}/{id?}"
			);
		});
	}
}

