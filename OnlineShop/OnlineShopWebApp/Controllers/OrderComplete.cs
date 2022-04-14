using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Services;

namespace OnlineShopWebApp.Controllers
{
    public class OrderCompleteController : Controller
    {
        private readonly ICartRepository cartRepository;

        public OrderCompleteController(ICartRepository cartRepository)
        {
            this.cartRepository = cartRepository;
        }
        public IActionResult Index()
        {
            cartRepository.RemoveAll();
            return View();
        }
        

    }
}
