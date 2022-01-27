using Grasmaster.Controllers;
using Grasmaster.Infrastructure.Context;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;


WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
//Add dbContext
string connString = builder.Configuration.GetConnectionString("MainConn");
builder.Services.AddDbContext<ApplicationDbContext>(options=> {
	options.UseSqlite("Data Source=GrasmasterDB.db;");
});
WebApplication app = builder.Build();

IServiceScope? scope = app.Services.CreateScope();

ApplicationDbContext dbcontext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

dbcontext.Database.EnsureDeleted();
dbcontext.Database.EnsureCreated();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Home/Error");
	app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Home}/{action=Index}/{id?}"
	);

app.Run();
