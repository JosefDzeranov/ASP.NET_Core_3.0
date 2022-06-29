using System.Collections.Generic;

namespace OnlineShop.Db.Models
{
    public class Language
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Culture { get; set; }
        public List<ProductResource> ProductResourses { get; set; }

        public Language(int id, string name, string culture)
        {
            Id = id;
            Name = name;
            Culture = culture;
        }
    }
}
