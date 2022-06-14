using System;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db.Interfase;
using OnlineShopWebApp.Helpers;
using OnlineShopWebApp.Interfase;

namespace OnlineShopWebApp.Controllers
{

    public class FavoriteController : Controller
    {
        private readonly IUsersManager _usersManager;
        private readonly IProductManager _productManager;
        private readonly IFavoriteManager _favoriteManager;
        public FavoriteController(IProductManager productManager, IFavoriteManager favoriteManager, IUsersManager usersManager)
        {
            _usersManager = usersManager;
            _productManager = productManager;
            _favoriteManager = favoriteManager;
        }

        public IActionResult Index()
        {
            var buyerLogin = _usersManager.GetLoginAuthorizedUser();
            var products = _favoriteManager.GetAll(buyerLogin);
            return View(Mapping.ToProductViewModels(products));
        }
        public IActionResult Add(Guid productId)
        {
            var buyerLogin = _usersManager.GetLoginAuthorizedUser();
            var product = _productManager.Find(productId);
            _favoriteManager.Add(buyerLogin, product);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Remove(Guid productId)
        {
            var buyerLogin = _usersManager.GetLoginAuthorizedUser();
            _favoriteManager.Remove(buyerLogin, productId);
            return RedirectToAction(nameof(Index));
        }
    }
}