using System;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db.Interfase;
using OnlineShopWebApp.Helpers;
using OnlineShopWebApp.Interfase;

namespace OnlineShopWebApp.Controllers
{

    public class ComparisonController : Controller
    {
        private readonly IUsersManager _usersManager;
        private readonly IProductRepository _productRepository;
        private readonly IComparisonRepository _comparisonRepository;
        public ComparisonController(IProductRepository productRepository, IComparisonRepository comparisonRepository, IUsersManager usersManager)
        {
            _usersManager = usersManager;
            _productRepository = productRepository;
            _comparisonRepository = comparisonRepository;
        }

        public IActionResult Index()
        {
            var buyerLogin = _usersManager.GetLoginAuthorizedUser();
            var products = _comparisonRepository.GetAll(buyerLogin);
            return View(Mapping.ToProduct_ViewModels(products));
        }
        public IActionResult Add(Guid productId)
        {
            var buyerLogin = _usersManager.GetLoginAuthorizedUser();
            var product = _productRepository.Find(productId);
            _comparisonRepository.Add(buyerLogin, product);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Remove(Guid productId)
        {
            var buyerLogin = _usersManager.GetLoginAuthorizedUser();
            _comparisonRepository.Remove(buyerLogin, productId);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Clear()
        {
            var buyerLogin = _usersManager.GetLoginAuthorizedUser();
            _comparisonRepository.Clear(buyerLogin);
            return RedirectToAction(nameof(Index));
        }
    }
}