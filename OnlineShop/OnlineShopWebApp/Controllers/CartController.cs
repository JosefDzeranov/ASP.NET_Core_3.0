using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Services;
using OnlineShopWebApp.Models;
namespace OnlineShopWebApp.Controllers
{
    public class CartController : Controller
    {
        private readonly IProductRepository productRepository;
        private readonly ICartRepository cartRepository;

        public CartController(IProductRepository productRepository, ICartRepository cartRepository)
        {
            this.productRepository = productRepository;
            this.cartRepository = cartRepository;

        }
        public IActionResult Index()
        {
            var cart = cartRepository.TryGetByUserId(Const.UserId);

            return View(cart);
        }

        public IActionResult Add(int productId)
        {

            var product = productRepository.TryGetById(productId);
            cartRepository.Add(product, Const.UserId);

            return RedirectToAction("Index");
        }

        public IActionResult Remove(int productId)
        {


            var product = productRepository.TryGetById(productId);
            cartRepository.RemoveItem(product, Const.UserId);

            return RedirectToAction("Index");
        }
        public IActionResult RemoveAll()
        {

           

            cartRepository.Clear(Const.UserId);


            return RedirectToAction("Index");
        }
    }
}
