using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.BL;
using System;
using System.Linq;
using ViewModels;

namespace OnlineShopWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductServicies _productServicies;
        private readonly IMapper _mapper;

        public HomeController(IProductServicies productServicies, IMapper mapper)
        {
            _productServicies = productServicies;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            var products = _productServicies.AllProducts().Where(x => x.AmountInDb > 0);
            return View(products.Select(x => _mapper.Map<ProductViewModel>(x)));
        }

        public IActionResult SearchByName(string rawSearchName)
        {
            var searchName = String.Empty;

            if (!string.IsNullOrEmpty(rawSearchName))
            {
                searchName = rawSearchName.ToLower();
            }
            var products = _productServicies.AllProducts().Select(x => _mapper.Map<ProductViewModel>(x)).Where(x => x.Name.ToLower().Contains(searchName));
            return View(products);
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}
