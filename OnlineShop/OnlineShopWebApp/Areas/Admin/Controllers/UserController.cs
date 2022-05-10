using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShopWebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UserController : Controller
    {
        private readonly IUsersRepository usersRepository;

        public UserController(IUsersRepository usersRepository)
        {
            this.usersRepository = usersRepository;
        }

        public IActionResult Users()
        {
            var users = usersRepository.GetAll();
            return View(users);
        }

        public IActionResult Details(string userLogin)
        {
            var user = usersRepository.TryGetByLogin(userLogin);
            return View(user);
        }

        //[HttpPost]
        //public IActionResult UpdateState(Guid orderId, OrderState state)
        //{
        //    ordersRepository.UpdateState(orderId, state);
        //    return RedirectToAction("Orders");
        //}
    }
}
