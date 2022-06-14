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
        private readonly IProductManager _productManager;
        private readonly IComparisonManager _comparisonManager;
        public ComparisonController(IProductManager productManager, IComparisonManager comparisonManager, IUsersManager usersManager)
        {
            _usersManager = usersManager;
            _productManager = productManager;
            _comparisonManager = comparisonManager;
        }

        public IActionResult Index()
        {
            var buyerLogin = _usersManager.GetLoginAuthorizedUser();
            var products = _comparisonManager.GetAll(buyerLogin);
            return View(Mapping.ToProductViewModels(products));
        }
        public IActionResult Add(Guid productId)
        {
            var buyerLogin = _usersManager.GetLoginAuthorizedUser();
            var product = _productManager.Find(productId);
            _comparisonManager.Add(buyerLogin, product);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Remove(Guid productId)
        {
            var buyerLogin = _usersManager.GetLoginAuthorizedUser();
            _comparisonManager.Remove(buyerLogin, productId);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Clear()
        {
            var buyerLogin = _usersManager.GetLoginAuthorizedUser();
            _comparisonManager.Clear(buyerLogin);
            return RedirectToAction(nameof(Index));
        }
    }
}