using At.Mausa.Grasmaster.Frontend;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;



CreateHostBuilder(args).Build().Run();

IHostBuilder CreateHostBuilder(string[] args) =>
Host.CreateDefaultBuilder(args)
    .ConfigureWebHostDefaults(webBuilder => {
        webBuilder.UseStartup<Startup>();
    });