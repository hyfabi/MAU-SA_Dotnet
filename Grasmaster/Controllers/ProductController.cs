using At.Mausa.Grasmaster.Domain.Models.Domain;
using At.Mausa.Grasmaster.Infrastructure.Services.Interfaces;

using Microsoft.AspNetCore.Mvc;

namespace at.mausa.grasmaster.frontend.Controllers; 

public class ProductController : Controller {

    private readonly ILogger<ProductController> logger;

    private IProductService productService;

    public ProductController(ILogger<ProductController> logger, IProductService productService) {
        this.productService = productService;
        this.logger = logger;
    }

    public IActionResult Index(){
        IQueryable<Product> products = productService.GetProducts(10);

        return View(products.ToList());
    }

}
