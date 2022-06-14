using At.Mausa.Grasmaster.Domain.Models;
using At.Mausa.Grasmaster.Infrastructure;
using At.Mausa.Grasmaster.Infrastructure.Services.Interfaces;

using Microsoft.AspNetCore.Mvc;

namespace At.Mausa.Grasmaster.Frontend.Controllers;

public class ProductController : Controller {

    private readonly ILogger<ProductController> logger;

    private IProductService productService;

    public ProductController(ILogger<ProductController> logger, IProductService productService) {
        this.productService = productService;
        this.logger = logger;
    }

    public IActionResult Index() {
        List<Product> products = productService.GetProducts();

        return View(products.ToList());
    }

    // GET: UserController/Details/5
    public ActionResult Details(int id) {
        return View();
    }

    // GET: UserController/Create
    public ActionResult Create() {
        return View(Product.AllProductTypeValues);
    }

    // POST: UserController/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create(IFormCollection collection) {
        productService.CreateProduct(ParseProduct(collection));

        try {
            return RedirectToAction(nameof(Index));
        } catch {
            return View();
        }
    }

    private Product ParseProduct(IFormCollection data) {
        string? desc = data["Description"];
        string? name = data["Name"];
        ProductType? type = (ProductType?)Enum.Parse(typeof(ProductType), data["art"]);

        Product product = new(null) {
            Description = desc ?? throw new NullReferenceException("Description should not be null"),
            Name = name ?? throw new NullReferenceException("Name should not be null"),
            ProductType = type ?? throw new NullReferenceException("Type should not be null")
        };
        return product;
    }

    // GET: UserController/Edit/as5-sasda-asd
    public ActionResult Edit(string id) {
        return View(new Tuple<Product, List<ProductType>>(productService.GetProduct(Guid.Parse(id)), Product.AllProductTypeValues));
    }

    // POST: UserController/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit(string id, IFormCollection collection) {

        productService.UpdateProduct(Guid.Parse(id), ParseProduct(collection));
        try {
            return RedirectToAction(nameof(Index));
        } catch {
            return View();
        }
    }

    // GET: UserController/Delete/5
    public ActionResult Delete(string id) {
        return View(productService.GetProduct(Guid.Parse(id)));
    }

    // POST: UserController/Delete/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Delete(string id, IFormCollection collection) {
        productService.DeleteProduct(Guid.Parse(id));
        try {
            return RedirectToAction(nameof(Index));
        } catch {
            return View();
        }
    }
}
