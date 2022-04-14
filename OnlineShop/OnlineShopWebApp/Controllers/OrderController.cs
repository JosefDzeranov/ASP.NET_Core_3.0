using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Models;
using OnlineShopWebApp.Services;

namespace OnlineShopWebApp.Controllers
{
    public class OrderController : Controller
    {
        private readonly ICartBase cartBase;
        private readonly IOrderBase orderBase;
        public OrderController(ICartBase cartBase, IOrderBase orderBase)
        {
            this.cartBase = cartBase;
            this.orderBase = orderBase;
        }

        public IActionResult Index()
        {
            var existingCart = cartBase.TryGetByUserId(Const.UserId);

            return View(existingCart);
        }

        public IActionResult Create()
        {
            var existingCart = cartBase.TryGetByUserId(Const.UserId);
            orderBase.Add(existingCart);
            cartBase.RemoveAll(Const.UserId);
            return View();
        }
    }
}
