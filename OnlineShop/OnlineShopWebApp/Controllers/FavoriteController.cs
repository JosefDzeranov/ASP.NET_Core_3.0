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
        private readonly IFavoriteRepository _favoriteRepository;
        public FavoriteController(IProductManager productManager, IFavoriteRepository favoriteRepository, IUsersManager usersManager)
        {
            _usersManager = usersManager;
            _productManager = productManager;
            _favoriteRepository = favoriteRepository;
        }

        public IActionResult Index()
        {
            var buyerLogin = _usersManager.GetLoginAuthorizedUser();
            var products = _favoriteRepository.GetAll(buyerLogin);
            return View(Mapping.ToProductViewModels(products));
        }
        public IActionResult Add(Guid productId)
        {
            var buyerLogin = _usersManager.GetLoginAuthorizedUser();
            var product = _productManager.Find(productId);
            _favoriteRepository.Add(buyerLogin, product);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Remove(Guid productId)
        {
            var buyerLogin = _usersManager.GetLoginAuthorizedUser();
            _favoriteRepository.Remove(buyerLogin, productId);
            return RedirectToAction(nameof(Index));
        }
    }
}