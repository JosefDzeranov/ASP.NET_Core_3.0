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
        private readonly IProductRepository _productRepository;
        private readonly IFavoriteRepository _favoriteRepository;
        public FavoriteController(IProductRepository productRepository, IFavoriteRepository favoriteRepository, IUsersManager usersManager)
        {
            _usersManager = usersManager;
            _productRepository = productRepository;
            _favoriteRepository = favoriteRepository;
        }

        public IActionResult Index()
        {
            var buyerLogin = _usersManager.GetLoginAuthorizedUser();
            var products = _favoriteRepository.GetAll(buyerLogin);
            return View(Mapping.ToProduct_ViewModels(products));
        }
        public IActionResult Add(Guid productId)
        {
            var buyerLogin = _usersManager.GetLoginAuthorizedUser();
            var product = _productRepository.Find(productId);
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