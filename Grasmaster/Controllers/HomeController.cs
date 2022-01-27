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
		private readonly ILogger<HomeController> _logger;

		public IProductService? ProductService { get; set; }

		public SeedingService? SeedingService { get; set; }

		public HomeController(ILogger<HomeController> logger)
		{
			_logger = logger;
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
			//DataSet ds = new DataSet();
			//string constr = "Data Source=GrasmasterDB.db;";
			//using (SqlConnection con = new(constr))
			//{
			//	string query = "SELECT * FROM Products";
			//	using (SqlCommand cmd = new (query))
			//	{
			//		cmd.Connection = con;
			//		using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
			//		{
			//			sda.Fill(ds);
			//		}
			//	}
			//}
			return View(new List<Product>() {
                new(null){Name = "a", Description = "a"},
                new(null){Name = "a1", Description = "a"},
                new(null){Name = "a2", Description = "a"},
                new(null){Name = "a3", Description = "a"},
                new(null){Name = "a4", Description = "a"},
                new(null){Name = "a5", Description = "a"},
                new(null){Name = "a6", Description = "a"},
                new(null){Name = "a7", Description = "a"},
                new(null){Name = "a8", Description = "a"},
                new(null){Name = "a9", Description = "a"},
                new(null){Name = "a10", Description = "a"},
                new(null){Name = "a11", Description = "a"},
                new(null){Name = "a12", Description = "a"}
			});
		}


		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}