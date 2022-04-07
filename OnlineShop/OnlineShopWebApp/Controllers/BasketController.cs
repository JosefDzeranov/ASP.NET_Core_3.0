using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OnlineShopWebApp.Models;


namespace OnlineShopWebApp.Controllers
{
    public class BasketController : Controller
    {
        private readonly CardRepository cardReposititory;

        //public BasketController()
        //{
        //    cardReposititory = new CardRepository();
        //}

        //public IActionResult Order(int id)
        //{
        //    var order = cardReposititory;
        //    return View(order);

        //}

    }
}
