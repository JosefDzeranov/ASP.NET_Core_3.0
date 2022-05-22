using System;
using System.ComponentModel.DataAnnotations;

namespace OnlineShopWebApp.Db.Models
{
    public class Product
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public decimal Cost { get; set; }

        public string Description { get; set; }
             

    }
}
