using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Domain.Abstract;
using Domain.Entitis;

namespace TorgiDemoMVC.UI.Controllers
{
    /// <summary>
    /// контроллер для добавления нового пользователя
    /// </summary>
    public class MainController : Controller
    {
        private IUserRepository _repository;

        public MainController(IUserRepository repository)
        {
            _repository = repository;
        }
        // GET: Main
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddUser(User user)
        {
            if (ModelState.IsValid)
            {
                _repository.AddUser(user);
                TempData["message"] = string.Format("User {0} has been saved", user.Email);
                return RedirectToAction("Index");
            }
            else
            {
                return View("Index");
            }
        }
    }
}