using At.Mausa.Grasmaster.Infrastructure.Services;
using At.Mausa.Grasmaster.Infrastructure.Services.Interfaces;

using Bogus.DataSets;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
        userService.CreateUser(new (null, ""));

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
