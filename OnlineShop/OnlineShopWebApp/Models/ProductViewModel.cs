using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OnlineShopWebApp.Models
{
    public class ProductViewModel
    {
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public decimal Cost { get; set; }

        [Required]
        public string Description { get; set; }

        public bool Available { get; set; }

        public List<string> ImagePaths { get; set; }

        public string ImagePath => ImagePaths.Count == 0 ? "/img/products/test.jpg" : ImagePaths[0];
    }
}
