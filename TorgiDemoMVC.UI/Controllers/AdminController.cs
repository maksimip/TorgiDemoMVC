using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Domain.Abstract;
using Domain.Concrete;
using Domain.Entitis;
using TorgiDemoMVC.UI.Models;

namespace TorgiDemoMVC.UI.Controllers
{
    /// <summary>
    /// контроллер для работы с объектом класса 'Product'
    /// </summary>
    public class AdminController : Controller
    {
        private IProductsRepository _repository;
        private IUserRepository _userRepository;

        public AdminController(IProductsRepository repository, IUserRepository userRepository)
        {
            _repository = repository;
            _userRepository = userRepository;
        }

        
        // GET: Admin
        public ActionResult Index()
        {
            return View(_repository.Products);
        }

        public ViewResult Edit(int id)
        {
            Product product = _repository.Products
                .FirstOrDefault(p => p.IdItem == id);
            return View(product);
        }

        [HttpPost]
        public ActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                int id = product.IdItem;
                _repository.UpdateProduct(product);
                if (id == 0)
                {
                    SendToEmail(product, "added");
                }
                else
                {
                    SendToEmail(product, "chenged");
                }
                TempData["message"] = string.Format("{0} has been saved", product.Name);
                return RedirectToAction("Index");
            }
            else
            {
                return View("Index");
            }
        }

        public ViewResult Create()
        {
            return View("Edit", new Product());
        }

        
        public ActionResult Delete(int id)
        {
            Product deletedProduct = _repository.DeleteProduct(id);
            if (deletedProduct != null)
            {
                TempData["message"] = string.Format("{0} was deleted", deletedProduct.Name);
                
            }
            SendToEmail(deletedProduct, "deleted");
            return RedirectToAction("Index");
        }

        //метод, формирующий список пользователей и текст сообщения для рассылки
        public void SendToEmail(Product product, string action)
        {
            IEnumerable<User> users;

            if (product.Category == "Cars")
            {
                users = _userRepository.Users.Select(u => u).Where(u => u.Cars == true);
            }
            else if (product.Category == "Jewelry")
            {
                users = _userRepository.Users.Select(u => u).Where(u => u.Jewelry == true);
            }
            else if (product.Category == "Realty")
            {
                users = _userRepository.Users.Select(u => u).Where(u => u.Realty == true);
            }
            else 
            {
                users = _userRepository.Users.Select(u => u).Where(u => u.Telephones == true);
            }
            

            if (users.Count() != 0)
            {
                EmailModel model = new EmailModel()
                {
                    Subject = product.Category,
                    Body = string.Format("Product {0} was {1}", product.Name, action)
                };

                EmailController controller = new EmailController();
                controller.SendMail(model, users).Deliver();
            }
        }
    }

}