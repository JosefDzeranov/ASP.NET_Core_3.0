using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db;
using OnlineShop.Db.Models;
using OnlineShopWebApp.Helpers;
using OnlineShopWebApp.Models;
using System;
using System.Collections.Generic;

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
            var orderListViewModels = Mapping.ToOrdersViewModels(ordersList);

            return View(orderListViewModels);

        }

        public IActionResult EditOrder(Guid id)
        {
            var order = orderManager.TryGetOrderById(id);

            return View(Mapping.ToOrderViewModel(order));

        }

        [HttpPost]
        public IActionResult UpdateStatus(Guid id, OrderStatusViewModel status)
        {

            orderManager.UpdateStatus(id, Mapping.ToOrderStatus(status));
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
        public IActionResult SaveNewUser(UserViewModel user)
        {
            if (ModelState.IsValid)
            {
                usersManager.SaveNewUser(user);

                return View("SaveAddedUser", user);
            }
            else
            {
                return RedirectToAction("AddNewUser");
            }

        }

        public IActionResult ShowUser(Guid id)
        {
            var user = usersManager.GetUserById(id);
            if (user != null)
            {
                return View(user);
            }
            else
            {
                return RedirectToAction("Users");
            }

        }
        public IActionResult ChangePassWord(Guid id)
        {
            var user = usersManager.GetUserById(id);
            if (user != null)
            {
                return View(user);
            }
            else
            {
                return RedirectToAction("ShowUser", id);
            }

        }

        public IActionResult EditUser(Guid id)
        {
            var user = usersManager.GetUserById(id);
            if (user != null)
            {
                return View(user);
            }
            else
            {
                return RedirectToAction("ShowUser", id);
            }

        }

        [HttpPost]
        public IActionResult SaveEditedUser(UserViewModel user)
        {
            if (ModelState.IsValid)
            {
                usersManager.EditUser(user);

                return RedirectToAction("Users");
            }
            else
            {
                return RedirectToAction("ChangePassWord", user.Id);
            }

        }

        public IActionResult DeleteUser(Guid id)
        {
            var user = usersManager.GetUserById(id);
            if (user != null)
            {
                usersManager.DeleteUser(user);
                return RedirectToAction("Users");
            }
            else
            {
                return RedirectToAction("ShowUser", id);
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
            var productList = productManager.GetAll();
            var pruductsViewModels = new List<ProductViewModel>();
            foreach (var product in productList)
            {
                var productViewModel = Mapping.ToProductViewModel(product);
                pruductsViewModels.Add(productViewModel);
            }
            return View(pruductsViewModels);
        }

        public IActionResult EditProduct(Guid id)
        {
            var product = productManager.TryGetById(id);
            var productViewModel = new ProductViewModel
            {
                Id = product.Id,
                Name = product.Name,
                Cost = product.Cost

            };
            return View(productViewModel);
        }

        [HttpPost]
        public IActionResult SaveEditedProduct(ProductViewModel product)
        {
            var productDb = new Product
            {
                Id = product.Id,
                Name = product.Name,
                Cost = product.Cost,
                Description = product.Description,
            };

            if (ModelState.IsValid)
            {
                productManager.EditProduct(productDb);

                return View();
            }
            else
            {
                return RedirectToAction("EditProduct");
            }

        }

        public IActionResult RemoveProduct(Guid id)
        {
            var product = productManager.TryGetById(id);
            productManager.GetAll().Remove(product);
            return View(product);
        }

        public IActionResult AddNewProduct()
        {

            return View();
        }

        [HttpPost]
        public IActionResult SaveAddedProduct(ProductViewModel product)
        {
            var productDb = new Product
            {
                Name = product.Name,
                Cost = product.Cost,
                Description = product.Description

            };


            if (ModelState.IsValid)
            {
                productManager.AddProduct(productDb);

                return View(product);
            }
            else
            {
                return RedirectToAction("AddNewProduct");
            }

        }
    }

}