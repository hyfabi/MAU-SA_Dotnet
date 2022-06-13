using At.Mausa.Grasmaster.Domain.Models;
using At.Mausa.Grasmaster.Infrastructure.Services;
using At.Mausa.Grasmaster.Infrastructure.Services.Interfaces;

using Bogus.DataSets;

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

    // GET: UserController/Details/5
    public ActionResult Details(int id) {
        return View();
    }

    // GET: UserController/Create
    public ActionResult Create() {
        return View();
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

    private Product ParseProduct(IFormCollection data){
        string? desc = data["Description"];
        string? name = data["Name"];

        Product product = new(null) {
            Description = desc ?? throw new NullReferenceException("Description should not be null"),
            Name = name ?? throw new NullReferenceException("Name should not be null")
        };
        return product;
    }

    // GET: UserController/Edit/as5-sasda-asd
    public ActionResult Edit(string id) {
        return View(productService.GetProduct(Guid.Parse(id)));
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
        productService.DeleteProduct(Guid.Parse(id));
        return RedirectToAction(nameof(Index));
    }
}
