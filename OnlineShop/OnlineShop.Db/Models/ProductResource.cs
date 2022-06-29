using System;
using System.Collections.Generic;

namespace OnlineShop.Db.Models
{
    public class ProductResource
    {
        public Guid Id { get; set; }
        public int LanguageId { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
        public Language Language { get; set; }
        public Product Product { get; set; }
    }
}
