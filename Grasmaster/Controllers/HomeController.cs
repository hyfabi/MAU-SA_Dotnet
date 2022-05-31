using Grasmaster.Infrastructure.Models;
using Grasmaster.Infrastructure.Services;
using Grasmaster.Infrastructure.Services.Interfaces;
using Grasmaster.Models;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

using System.Data;
using System.Diagnostics;

namespace Grasmaster.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> logger;

		private IProductService productService;

		public HomeController(ILogger<HomeController> logger, IProductService productService)
		{
			this.logger = logger;
			this.productService = productService;
		}

		public IActionResult Index()
		{
			return View();
		}

		public IActionResult Privacy()
		{
			return View();
		}

		public IActionResult Product()
		{
			return View(productService.GetProducts(10));
		}


		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}