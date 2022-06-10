using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OnlineShopWebApp.Models
{
    public class ProductViewModel
    {
        
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal Cost { get; set; }
        public string Description { get; set; }

        public string MainImagePath { 
            get 
            {
                return ImagesPaths.Count == 0 ? "/images/book.png" : ImagesPaths[0];
            } 
        }
        public List<string> ImagesPaths { get; set; }

    }
}
