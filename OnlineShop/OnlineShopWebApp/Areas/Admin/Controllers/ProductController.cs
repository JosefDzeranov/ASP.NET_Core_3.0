using AutoMapper;
using Domains;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.BL;
using OnlineShop.DB;
using System.Linq;
using ViewModels;

namespace OnlineShopWebApp.Areas.Admin.Controllers
{
    [Area(Const.AdminRoleName)]
    [Authorize(Roles = Const.AdminRoleName)]
    public class ProductController : Controller
    {
        private readonly IProductServicies _productServicies;
        private readonly IMapper _mapper;

        public ProductController(IProductServicies productServicies, IMapper mapper)
        {
            _productServicies = productServicies;
            _mapper = mapper;
        }

        public IActionResult Products()
        {
            var products = _productServicies.AllProducts().Select(x => _mapper.Map<ProductViewModel>(x));
            return View(products);
        }

        public IActionResult AddNewProduct()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddNewProduct(ProductViewModel product)
        {
            if (ModelState.IsValid)
            {
                _productServicies.Add(_mapper.Map<Product>(product));
                return RedirectToAction("Products", "Product");
            }
            else
            {
                return View("AddNewProduct");
            }

        }

        [HttpGet]
        public IActionResult EditProduct(int productId)
        {
            var product = _productServicies.TryGetById(productId);
            return View(product);
        }

        [HttpPost]
        public IActionResult EditProduct(Product product)
        {
            if (ModelState.IsValid)
            {
                _productServicies.Edit(product);
                return RedirectToAction("products", "product");
            }
            else
            {
                return View("EditProduct", product);
            }

        }

        public IActionResult DeleteProduct(int productId)
        {
            _productServicies.Delete(productId);
            return RedirectToAction("Products", "Product");
        }

    }
}
