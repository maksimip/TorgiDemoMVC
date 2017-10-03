using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Domain.Abstract;
using Domain.Entitis;

namespace TorgiDemoMVC.UI.Controllers
{
    public class UserController : Controller
    {
        private IUserRepository _repository;

        public UserController(IUserRepository repository)
        {
            _repository = repository;
        }
        // GET: User
        public ActionResult Index()
        {
            return View(_repository.Users);
        }

        public ViewResult EditUser(int id)
        {
            User user = _repository.Users.FirstOrDefault(u => u.Id == id);
            return View(user);
        }

        [HttpPost]
        public ActionResult EditUser(User user)
        {
            if (ModelState.IsValid)
            {
                _repository.UpdateUser(user);
                TempData["message"] = string.Format("{0} was changed successfully", user.Email);
                return RedirectToAction("Index");
            }
            else
            {
                return View("Index");
            }
        }

        public ActionResult DeleteUser(int id)
        {
            User deletedUser = _repository.DeleteUser(id);
            if (deletedUser != null)
            {
                TempData["message"] = string.Format("User {0} was deleted successfully", deletedUser.Email);
            }
            return RedirectToAction("Index");
        }
    }
}