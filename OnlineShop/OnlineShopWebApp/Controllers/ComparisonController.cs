using System;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db.Interfase;
using OnlineShopWebApp.Helpers;
using OnlineShopWebApp.Interfase;

namespace OnlineShopWebApp.Controllers
{

    public class ComparisonController : Controller
    {
        private readonly IUserManager _userManager;
        private readonly IProductManager _productManager;
        private readonly IFavoriteRepository _favoriteRepository;
        public ComparisonController(IProductManager productManager, IFavoriteRepository favoriteRepository, IUserManager userManager)
        {
            _userManager = userManager;
            _productManager = productManager;
            _favoriteRepository = favoriteRepository;
        }

        public IActionResult Index()
        {
            var buyerLogin = _userManager.GetLoginAuthorizedUser();
            var products = _favoriteRepository.GetAll(buyerLogin);
            return View(Mapping.ToProductViewModels(products));
        }
        public IActionResult Add(Guid productId)
        {
            var buyerLogin = _userManager.GetLoginAuthorizedUser();
            var product = _productManager.Find(productId);
            _favoriteRepository.Add(buyerLogin, product);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Remove(Guid productId)
        {
            var buyerLogin = _userManager.GetLoginAuthorizedUser();
            _favoriteRepository.Remove(buyerLogin, productId);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Clear()
        {
            var buyerLogin = _userManager.GetLoginAuthorizedUser();
            _favoriteRepository.Clear(buyerLogin);
            return RedirectToAction(nameof(Index));
        }
    }
}