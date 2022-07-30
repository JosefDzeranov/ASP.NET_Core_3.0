using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db;
using OnlineShop.Db.Models;
using OnlineShopWebApp.Helpers;
using OnlineShopWebApp.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace OnlineShopWebApp.Controllers
{
    [Area(Constants.AdminRoleName)]
    [Authorize(Roles = Constants.AdminRoleName)]
    public class AdministrationController : Controller
    {
        private readonly IProductManager productManager;
        private readonly IOrderManager orderManager;

        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        private readonly IWebHostEnvironment appEnvironment;

        public AdministrationController(IProductManager productManager, IOrderManager orderManager, UserManager<User> userManager, RoleManager<IdentityRole> roleManager, IWebHostEnvironment appEnvironment)
        {
            this.productManager = productManager;
            this.orderManager = orderManager;

            _userManager = userManager;
            _roleManager = roleManager;

            this.appEnvironment = appEnvironment;
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

                var newUser = new User { UserName = user.Login, PhoneNumber = user.Phone, Id = user.Id.ToString() };
                var result = _userManager.CreateAsync(newUser, user.Password).Result;
                TryAssignRole(newUser);


                return View("SaveAddedUser", newUser);
            }
            else
            {
                return RedirectToAction("AddNewUser");
            }

        }

        private void TryAssignRole(User user)
        {
            try
            {
                _userManager.AddToRoleAsync(user, Constants.UserRoleName).Wait();
            }
            catch (Exception)
            {


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

            user.UserName = userView.Name;
            user.PhoneNumber = userView.Phone;

            _userManager.UpdateAsync(user).Wait();


            return RedirectToAction("Users");


        }

        public IActionResult EditUserRights(string name)
        {
            var user = _userManager.FindByNameAsync(name).Result;
            var userRoles = _userManager.GetRolesAsync(user).Result;
            var allRoles = _roleManager.Roles.ToList();

            var editRightsViewModel = new EditRightsViewModel()
            {
                UserRoles = userRoles.Select(x => new RoleViewModel { Name = x }).ToList(),
                UserName = user.UserName,
                AllRoles = allRoles.Select(x => new RoleViewModel { Name = x.Name }).ToList()
            };
            return View(editRightsViewModel);
        }

        [HttpPost]
        public IActionResult EditRights(string userName, Dictionary<string, string> userRolesViewModel)
        {
            var userSelectedRoles = userRolesViewModel.Select(x => x.Key);

            var user = _userManager.FindByNameAsync(userName).Result;
            var userRoles = _userManager.GetRolesAsync(user).Result;
            _userManager.RemoveFromRolesAsync(user, userRoles).Wait();
            _userManager.AddToRolesAsync(user, userSelectedRoles).Wait();

            return RedirectToAction("EditUserRights", new { name = userName });
        }

        public IActionResult DeleteUser(string name)
        {
            var user = _userManager.FindByNameAsync(name).Result;
            _userManager.DeleteAsync(user).Wait();
            return RedirectToAction("Users");

        }


        public IActionResult Roles()
        {

            List<IdentityRole> roles = _roleManager.Roles.ToList();
            return View(Mapping.ToRoleViewModels(roles));
        }

        public IActionResult AddRole()
        {

            return View();
        }

        [HttpPost]
        public IActionResult AddRole(RoleViewModel roleView)
        {
            var result = _roleManager.CreateAsync(new IdentityRole(roleView.Name)).Result;

            if (result.Succeeded)
            {
                return RedirectToAction("Roles");

            }
            else
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            return View(roleView);

        }



        public IActionResult RemoveRole(string name)
        {
            var role = _roleManager.FindByNameAsync(name).Result;
            _roleManager.DeleteAsync(role).Wait();

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
           
            Product productDb = new Product();

            if (product.UploadedFile != null)
            {
                string productImagesPath = Path.Combine(appEnvironment.WebRootPath + "/images/products/");
                if (!Directory.Exists(productImagesPath))
                {
                    Directory.CreateDirectory(productImagesPath);
                }

                var fileName = Guid.NewGuid() + "." + product.UploadedFile.FileName.Split('.').Last();
                using (var fileStream = new FileStream(productImagesPath + fileName, FileMode.Create))
                {
                    product.UploadedFile.CopyTo(fileStream);
                }

                productDb = new Product
                {
                    Id = product.Id,
                    Name = product.Name,
                    Cost = product.Cost,
                    Description = product.Description,
                    ImagePath = "/images/products/" + fileName
                };
            }
            else
            {
                productDb = new Product
                {
                    Id = product.Id,
                    Name = product.Name,
                    Cost = product.Cost,
                    Description = product.Description,

                };
            }

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
            productManager.RemoveProduct(product);
            return View(Mapping.ToProductViewModel(product));
        }

        public IActionResult AddNewProduct()
        {

            return View();
        }


        [HttpPost]
        public IActionResult SaveAddedProduct(ProductViewModel product)
        {
            Product productDb = new Product();

            if (product.UploadedFile != null)
            {
                string productImagesPath = Path.Combine(appEnvironment.WebRootPath + "/images/products/");
                if (!Directory.Exists(productImagesPath))
                {
                    Directory.CreateDirectory(productImagesPath);
                }

                var fileName = Guid.NewGuid() + "." + product.UploadedFile.FileName.Split('.').Last();
                using (var fileStream = new FileStream(productImagesPath + fileName, FileMode.Create))
                {
                    product.UploadedFile.CopyTo(fileStream);
                }

                productDb = new Product
                {
                    Id = product.Id,
                    Name = product.Name,
                    Cost = product.Cost,
                    Description = product.Description,
                    ImagePath = "/images/products/" + fileName
                };
            }
            else
            {
                productDb = new Product
                {
                    Id = product.Id,
                    Name = product.Name,
                    Cost = product.Cost,
                    Description = product.Description,

                };
            }


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