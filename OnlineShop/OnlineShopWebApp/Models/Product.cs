using System.ComponentModel.DataAnnotations;

namespace OnlineShopWebApp.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Не указано наименование услуги")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Не указана стоимость услуги")]
        public decimal Cost { get; set; }

        [Required(ErrorMessage = "Не заполнено описание услуги")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Не приложено фото")]
        public string ImagePath { get; set; }

        //public Product() { }

        public Product(int id,string name, decimal cost, string description, string imagePath)
        {
            Id = id;

            Name = name;

            Cost = cost;

            Description = description;
            
            ImagePath = imagePath;
        }
    }
}
