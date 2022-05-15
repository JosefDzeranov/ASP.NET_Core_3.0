using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Models;
using System;

namespace OnlineShopWebApp.Controllers
{
    [Area("Admin")]
    public class AdministrationController : Controller
    {
        private readonly IProductManager productManager;
        private readonly IOrderManager orderManager;
        private readonly IRolesManager rolesManager;
        private readonly IUsersManager usersManager;

        public AdministrationController(IProductManager productManager, IOrderManager orderManager, IRolesManager rolesManager, IUsersManager usersManager)
        {
            this.productManager = productManager;
            this.orderManager = orderManager;
            this.rolesManager = rolesManager;
            this.usersManager = usersManager;
        }

        public IActionResult Index()
        {

            return RedirectToAction("Orders");
        }

        public IActionResult Orders()
        {
            var ordersList = orderManager.GetOrders();

            return View(ordersList);

        }

        public IActionResult EditOrder(Guid id)
        {
            var order = orderManager.TryGetOrderById(id);

            return View(order);

        }

        [HttpPost]
        public IActionResult UpdateStatus(Guid id, OrderStatus status)
        {

            orderManager.UpdateStatus(id, status);
            return RedirectToAction("Orders");

        }

        public IActionResult Users()
        {
            var users = usersManager.GetRegistredUsers();
            return View(users);
        }
        public IActionResult AddNewUser()
        {
            
            return View();
        }

        [HttpPost]
        public IActionResult SaveNewUser(User user)
        {
            if (ModelState.IsValid)
            {
                usersManager.SaveNewUser(user);

                return View("SaveAddedUser",user);
            }
            else
            {
                return RedirectToAction("AddNewUser");
            }

           
        }

        public IActionResult Roles()
        {
            var roles = rolesManager.Roles;
            return View(roles);
        }

        public IActionResult AddRole()
        {

            return View();
        }

        [HttpPost]
        public IActionResult AddRole(Role role)
        {

            if (rolesManager.TryFindByName(role.Name) != null)
            {
                ModelState.AddModelError("", "такая роль уже есть");

            }

            if (ModelState.IsValid)
            {
                rolesManager.AddRole(role);
                return RedirectToAction("Roles");
            }

            return View(role);


        }




        public IActionResult RemoveRole(string name)
        {
            rolesManager.RemoveRole(name);

            return RedirectToAction("Roles");
        }

        public IActionResult Products()
        {
            var productList = productManager.ProductList;
            return View(productList);
        }

        public IActionResult EditProduct(int id)
        {
            var product = productManager.FindProduct(id);
            return View(product);
        }

        [HttpPost]
        public IActionResult SaveEditedProduct(Product product)
        {

            if (ModelState.IsValid)
            {
                productManager.EditProduct(product);

                return View();
            }
            else
            {
                return RedirectToAction("EditProduct");
            }

        }

        public IActionResult RemoveProduct(int id)
        {
            var product = productManager.FindProduct(id);
            productManager.ProductList.Remove(product);
            return View(product);
        }

        public IActionResult AddNewProduct()
        {

            return View();
        }

        [HttpPost]
        public IActionResult SaveAddedProduct(Product product)
        {
            if (ModelState.IsValid)
            {
                productManager.ProductList.Add(product);

                return View(product);
            }
            else
            {
                return RedirectToAction("AddNewProduct");
            }

        }
    }

}