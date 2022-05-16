using OnlineShopWebApp.Controllers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShop.Db
{
    public class Product
    {
        private static int constantCounter = 0;
        public int Id { get; set; }

        [Required(ErrorMessage = "Введите название книги")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Введите стоимость")]
        public decimal Cost { get; set; }

        [Required(ErrorMessage = "Введите описание")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Введите количество страниц")]
        public int Pages { get; set; }

        public Product()
        {
            Id = constantCounter;
            constantCounter++;        
        }
    }
}
