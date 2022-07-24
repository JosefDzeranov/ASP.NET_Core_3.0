using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db;
using OnlineShop.Db.Models;
using OnlineShopWebApp.Helpers;
using OnlineShopWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OnlineShopWebApp.Controllers
{
    [Area(Constants.AdminRoleName)]
    [Authorize(Roles = Constants.AdminRoleName)]
    public class AdministrationController : Controller
    {
        private readonly IProductManager productManager;
        private readonly IOrderManager orderManager;
        private readonly IRolesManager rolesManager;
        //  private readonly IUsersManager usersManager;

        private readonly UserManager<User> _userManager;

        public AdministrationController(IProductManager productManager, IOrderManager orderManager, IRolesManager rolesManager, UserManager<User> userManager)
        {
            this.productManager = productManager;
            this.orderManager = orderManager;
            this.rolesManager = rolesManager;
            _userManager = userManager;
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
            var users = Mapping.ToUserModelViews(_userManager.Users.ToList());

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

                var newUser = new User { UserName = user.Login, PhoneNumber = user.Phone, Id = user.Id.ToString()};
                var result = _userManager.CreateAsync(newUser, user.Password).Result;


                return View("SaveAddedUser", newUser);
            }
            else
            {
                return RedirectToAction("AddNewUser");
            }

        }

        public IActionResult ShowUser(string name)
        {
            var user = _userManager.FindByNameAsync(name).Result;
            return View(Mapping.ToUserViewModel(user));


        }
        public IActionResult ChangePassWord(string name)
        {
            var changePassword = new ChangePassWord { UserName = name };
            return View(changePassword);
           
        }


        [HttpPost]
        public IActionResult ChangePassWord(ChangePassWord changePassWord)
        {
            if (changePassWord.UserName == changePassWord.Password)
            {
                ModelState.AddModelError("", "Login and password should not be same");
            }
            if (ModelState.IsValid)
            {
                var user = _userManager.FindByNameAsync(changePassWord.UserName).Result;
                user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, changePassWord.Password);
                _userManager.UpdateAsync(user).Wait();
               
            }

            return RedirectToAction("Users");
        }

        public IActionResult EditUser(string name)
        {
            var user = Mapping.ToUserViewModel(_userManager.FindByNameAsync(name).Result);
            
            if (user != null)
            {
                return View(user);
            }
            else
            {
                return RedirectToAction("ShowUser", name);
            }

        }

        [HttpPost]
        public IActionResult SaveEditedUser(UserViewModel userView)
        {
            
            var user = _userManager.FindByIdAsync(userView.Id.ToString()).Result;
          
           user.UserName = userView.Name;// изменится имя и невозможен будет поиск
            user.PhoneNumber = userView.Phone;

                _userManager.UpdateAsync(user).Wait();
               

                return RedirectToAction("Users");
          

        }

        public IActionResult DeleteUser(string name)
        {
            var user = _userManager.FindByNameAsync(name).Result;
            _userManager.DeleteAsync(user).Wait();
            return RedirectToAction("Users");

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