using AutoMapper;
using Domains;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.DB;
using OnlineShopWebApp.Areas.Admin.Models;
using System.Linq;
using ViewModels;

namespace OnlineShopWebApp.Areas.Admin.Controllers
{
    [Area(Const.AdminRoleName)]
    [Authorize(Roles = Const.AdminRoleName)]
    public class UserController : Controller
    {

        private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;

        public UserController(UserManager<User> userManager, IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
        }

        public IActionResult Users()
        {
            var users = _userManager.Users.Select(x=> _mapper.Map<UserViewModel>(x)).ToList();
            return View(users);
        }

        private User GetUserFromDB(string userId)
        {
            return _userManager.Users.FirstOrDefault(x => x.Id == userId);
        }

        public IActionResult Get(string userId)
        {
            var necessaryUser = _mapper.Map<UserViewModel>(_userManager.Users.FirstOrDefault(x => x.Id == userId));
            return View(necessaryUser);
        }

        [HttpGet]
        public IActionResult ChangePassword(string userId)
        {
            var necessaryUser = _userManager.Users.FirstOrDefault(x => x.Id == userId);
            var newPassword = new NewPassword
            {
                UserId = userId
            };
            return View(newPassword);
        }

        [HttpPost]
        public IActionResult ChangePassword(NewPassword newPassword)
        {
            if (ModelState.IsValid)
            {
                var user = GetUserFromDB(newPassword.UserId);
                var result = _userManager.RemovePasswordAsync(user).Result;
                if(result.Succeeded)
                {
                    _userManager.AddPasswordAsync(user, newPassword.Password).Wait();
                }
                return RedirectToAction("Get", "User", new { userId = newPassword.UserId });
            }
            else
            {
                return View("Users");
            }
        }

        [HttpGet]
        public IActionResult Edit(string userId)
        {
            var necessaryUser = GetUserFromDB(userId);
            return View(_mapper.Map<UserViewModel>(necessaryUser));
        }

        [HttpPost]
        public IActionResult Edit(UserViewModel user)
        {
            if (ModelState.IsValid)
            {
                var userToEdit = _userManager.FindByNameAsync(user.Login).Result;

                userToEdit.FirstName = user.FirstName;
                userToEdit.LastName = user.LastName;
                userToEdit.PhoneNumber = user.Phone;

                var result = _userManager.UpdateAsync(userToEdit).Result;
                return RedirectToAction("Get", "User", new { userId = user.Id });
            }
            else
            {
                return View("Users");
            }
        }

        public IActionResult Delete(string userId)
        {
            var result = _userManager.DeleteAsync(GetUserFromDB(userId)).Result;
            if(result.Succeeded)
            {
                return RedirectToAction("Users", "User");
            }
            else
            {
                return View();
            }
            
        }
    }
}
