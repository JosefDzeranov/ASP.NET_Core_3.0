using Microsoft.AspNetCore.Mvc;
using OnlineShop.db;
using OnlineShop.Db;
using OnlineShopWebApp.Services;
using OnlineShopWebApp.Helpers;
using System.Linq;


namespace OnlineShopWebApp.Controllers
{
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
            //var viewModelDict = cartRepository.CartItems.ToDictionary(k => Mapping.ToProductViewModel(k.Key), v=>v.Value);
            return View(Mapping.ToCartViewModel(cartRepository.TryGetByUserId(Const.UserId)));
        }

        public IActionResult Add(int productId)
        {
            cartRepository.Add(productId, Const.UserId);
            return RedirectToAction("Index");
        }

        public IActionResult RemoveProduct(int productId)
        {
            cartRepository.Remove(productId, Const.UserId);
            return RedirectToAction("Index");
        }

        public IActionResult RemoveAll(string userId)
        {
            cartRepository.RemoveAll(userId);
            return RedirectToAction("Index");
        }

    }
}


