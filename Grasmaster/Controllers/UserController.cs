using At.Mausa.Grasmaster.Domain.Models;
using At.Mausa.Grasmaster.Infrastructure.Services;
using At.Mausa.Grasmaster.Infrastructure.Services.Interfaces;

using Bogus.DataSets;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using System.IO;

using Address = At.Mausa.Grasmaster.Domain.Models.Address;
using User = At.Mausa.Grasmaster.Domain.Models.User;

namespace At.Mausa.Grasmaster.Frontend.Controllers; 
public class UserController : Controller {

    private IUserService userService;

    public UserController(IUserService iuserService){
        userService = iuserService;
    }

    // GET: UserController
    public ActionResult Index() {
        return View(userService.GetUsers().ToList());
    }

    // GET: UserController/Details/5asdawds
    public ActionResult Details(string id) {
        return View(userService.GetUser(Guid.Parse(id)));
    }

    // GET: UserController/Create
    public ActionResult Create() {
        return View();
    }

    private User ParseUser(IFormCollection data) {
        string? email = data["email"];    
        string? password = data["password"];
        string? name = data["name"];
        Address address = ParseAddress(data);

        User user = new User(null, name ?? throw new ArgumentNullException("Name cannot be null")) {
            Email = email ?? throw new ArgumentNullException("Name cannot be null"),
            PasswordHash = password ?? throw new ArgumentNullException("Name cannot be null"),
            Address = address
        };
        return user;
    }

    private Address ParseAddress(IFormCollection data) {
        string? street = data["street"];
        string? country = data["country"];
        string? city = data["city"];

        Address address = new() {
            Street = street ?? throw new ArgumentException("Street cannot be null!"),
            Country = country ?? throw new ArgumentException("Country cannot be null!"),
            City = city ?? throw new ArgumentException("City cannot be null!")
        };
        return address;
    }

    // POST: UserController/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create(IFormCollection collection) {
        userService.CreateUser(ParseUser(collection));
        try {
            return RedirectToAction(nameof(Index));
        } catch {
            return View();
        }
    }

    // GET: UserController/Edit/5
    public ActionResult Edit(int id) {
        return View();
    }

    // POST: UserController/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit(int id, IFormCollection collection) {
        try {
            return RedirectToAction(nameof(Index));
        } catch {
            return View();
        }
    }

    // GET: UserController/Delete/5
    public ActionResult Delete(int id) {
        return View();
    }

    // POST: UserController/Delete/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Delete(int id, IFormCollection collection) {
        try {
            return RedirectToAction(nameof(Index));
        } catch {
            return View();
        }
    }
}
