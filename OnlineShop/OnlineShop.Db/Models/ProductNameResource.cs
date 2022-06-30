using System;
using System.Collections.Generic;

namespace OnlineShop.Db.Models
{
    public class ProductNameResource
    {
        public Guid Id { get; set; }
        public int LanguageId { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
        public Language Languages { get; set; }
        public Product Product { get; set; }
    }
}
