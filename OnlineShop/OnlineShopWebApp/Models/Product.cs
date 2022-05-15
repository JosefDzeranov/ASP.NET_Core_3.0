using OnlineShopWebApp.Models.Attributes;
using System.ComponentModel.DataAnnotations;

namespace OnlineShopWebApp.Models
{
    [DesriptionLengthName]
    public class Product
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Введите название продукта")]

        public string Name { get; set; }
        [Required(ErrorMessage = "Введите стоимость продукта")]

        public decimal Cost { get; set; }
        [Required(ErrorMessage = "Введите описание продукта")]

        public string Description { get; set; }

        public string? ImgPath { get; set; }

        public Product(int id, string name, decimal cost)
        {
            Id = id;
            Name = name;
            Cost = cost;
        }

        public Product(int id, string name, decimal cost, string description)
        {
            Id = id;
            Name = name;
            Cost = cost;
            Description = description;
        }

        public Product() { }
        
    }
}
