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
        private readonly IComparisonRepository _comparisonRepository;
        public ComparisonController(IProductManager productManager, IComparisonRepository comparisonRepository, IUserManager userManager)
        {
            _userManager = userManager;
            _productManager = productManager;
            _comparisonRepository = comparisonRepository;
        }

        public IActionResult Index()
        {
            var buyerLogin = _userManager.GetLoginAuthorizedUser();
            var products = _comparisonRepository.GetAll(buyerLogin);
            return View(Mapping.ToProductViewModels(products));
        }
        public IActionResult Add(Guid productId)
        {
            var buyerLogin = _userManager.GetLoginAuthorizedUser();
            var product = _productManager.Find(productId);
            _comparisonRepository.Add(buyerLogin, product);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Remove(Guid productId)
        {
            var buyerLogin = _userManager.GetLoginAuthorizedUser();
            _comparisonRepository.Remove(buyerLogin, productId);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Clear()
        {
            var buyerLogin = _userManager.GetLoginAuthorizedUser();
            _comparisonRepository.Clear(buyerLogin);
            return RedirectToAction(nameof(Index));
        }
    }
}