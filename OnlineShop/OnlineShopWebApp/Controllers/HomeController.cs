using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OnlineShopWebApp.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShopWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public List<string> Index()
        {
            var items = new List<Item>();
            var item1 = new Item();
            var item2 = new Item();
            var item3 = new Item();

            items.Add(item1);
            items.Add(item2);
            items.Add(item3);

            //foreach (var item in items)
            //{
            //    Console.WriteLine(item.Id);
            //    Console.WriteLine(item.Name);
            //    Console.WriteLine(item.Cost);
            //    Console.WriteLine();
            //}

            var itemsInfo = new List<string>();

            foreach (var item in items)
            {
                var itemInfo = item.ToString().Split(',');

                for (int i = 0; i < itemInfo.Length; i++)
                {
                    itemsInfo.Add(itemInfo[i]);
                }
            }

            return itemsInfo;
        }

        public class Item
        {
            string id;
            string name;
            string cost;
            string description;
            private static int cnt;

            public string Id
            {
                get
                {
                    return id;
                }
                set
                {
                    id = $"Id{cnt}";
                }

            }
            public string Name
            {
                get
                {
                    return name;
                }
                set
                {
                    name = $"Name{cnt}";
                }
            }
            public string Cost
            {
                get
                {
                    return cost;
                }
                set
                {
                    cost = $"Cost{cnt}";
                }
            }
            public string Description
            {
                get
                {
                    return description;
                }
                set
                {
                    description = $"{value}{cnt}";
                }
            }

            public Item()
            {
                cnt++;
                Id = id;
                Name = name;
                Cost = cost;
            }

            public override string ToString()
            {
                return $"{Id},{Name},{Cost}";
            }
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
