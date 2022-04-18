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

<<<<<<< HEAD
            var product = productBase.TryGetById(productId);
            cartBase.RemoveItem(product, Const.UserId);
=======
            var product = productRepository.TryGetById(productId);
            cartRepository.Remove(product, Const.UserId);
>>>>>>> karpunin_lesson4_5

            return RedirectToAction("Index");
        }
        public IActionResult RemoveAll()
        {

           
<<<<<<< HEAD
            cartBase.Clear(Const.UserId);
=======
            cartRepository.RemoveAll(Const.UserId);
>>>>>>> karpunin_lesson4_5

            return RedirectToAction("Index");
        }
    }
}
