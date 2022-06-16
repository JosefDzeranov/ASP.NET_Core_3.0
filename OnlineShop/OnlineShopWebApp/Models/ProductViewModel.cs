using OnlineShop.db.Models;
using System.ComponentModel.DataAnnotations;
namespace OnlineShopWebApp.Models
{
    public class ProductViewModel
    {
        private static int instanceCounter = 0;

        public int Id { get; set; }

        [Required(ErrorMessage = "Не указано имя")]
        [StringLength(50, MinimumLength = 4, ErrorMessage = "Название продукта должно быть от 4 до 50 символов")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Не указана цена продукта")]
        public decimal Cost { get; set; }

        [Required(ErrorMessage = "Описание продукта не может быть пустым")]
        public string Description { get; set; }

        public string[] ImagesPath { get; set; }

        public string ImagePath => ImagesPath.Length == 0 ? "/images/india.jpg" : ImagesPath[0];

        public static int GetNextId()
        {
            instanceCounter += 1;
            return instanceCounter;
        }

        public static ProductViewModel ConvertFromDbProduct(Product product)
        {
            return new ProductViewModel()
            {
                Id = product.Id,
                Name = product.Name,
                Cost = product.Cost,
                Description = product.Description
            };
        }
    }

}
