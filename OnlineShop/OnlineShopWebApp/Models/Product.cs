using System.ComponentModel.DataAnnotations;

namespace OnlineShopWebApp
{
    public class Product
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Не указано название")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Не указана цена")]
        public decimal Cost { get; set; }

        [Required(ErrorMessage = "Не указано описание")]
        public string Description { get; set; }
        
        public Product(int id, string name, decimal cost, string description)
        {
            Id = id;
            Name = name;
            Cost = cost;
            Description = description;

        }

        public Product()
        {

        }

    }
}
