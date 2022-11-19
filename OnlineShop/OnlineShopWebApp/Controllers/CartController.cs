using Microsoft.AspNetCore.Mvc;
using OnlineShop.db;
using OnlineShopWebApp.Services;
using OnlineShopWebApp.Helpers;
using Microsoft.AspNetCore.Authorization;


namespace OnlineShopWebApp.Controllers
{
    [Authorize]
    public class CartController : Controller
    {
        private readonly IProductDataSource productDataSource;

        private readonly ICartRepository cartRepository;
   
        public CartController(ICartRepository cartRepository, IProductDataSource productDataSource)
        {
            this.cartRepository = cartRepository;
            this.productDataSource = productDataSource;
        }
        public IActionResult Index()
        {
            var user = User.Identity.Name;
            //var viewModelDict = cartRepository.CartItems.ToDictionary(k => Mapping.ToProductViewModel(k.Key), v=>v.Value);
            return View(Mapping.ToCartViewModel(cartRepository.TryGetByUserId(User.Identity.Name)));
        }

        public IActionResult Add(int productId)
        {
            cartRepository.Add(productId, User.Identity.Name);
            return RedirectToAction("Index");
        }

        public IActionResult RemoveProduct(int productId)
        {
            cartRepository.Remove(productId, User.Identity.Name);
            return RedirectToAction("Index");
        }

        public IActionResult RemoveAll()
        {
            cartRepository.RemoveAll(User.Identity.Name);
            return RedirectToAction("Index");
        }

    }
}


