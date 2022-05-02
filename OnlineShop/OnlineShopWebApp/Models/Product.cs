using System.ComponentModel.DataAnnotations;
namespace OnlineShopWebApp.Models
{
    public class Product
    {
        private static int instanceCounter =0;

        public int Id { get; set; }

        [Required(ErrorMessage ="Не указано имя")]
        [StringLength(50, MinimumLength=4, ErrorMessage ="Название продукта должно быть от 4 до 50 символов")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Не указана цена продукта")]
        public decimal Cost { get; set; }  
        
        [Required(ErrorMessage ="Описание продукта не может быть пустым")]
        public string Description { get; set; }

        public string ImagePath { get; set; }

		public Product()
		{
        }

		public Product(string name, decimal cost, string description, string imagePath)
		{
            Id = GetNextId();
			Name = name;
			Cost = cost;
			Description = description;
            ImagePath = imagePath;
		}

		public override string ToString()
        {
            return $"Id {this.Id}\nName {this.Name}\nCost {this.Cost}\nDescription {this.Description}\n\n";
        }

        public static int GetNextId()
        {
            instanceCounter += 1;

            return instanceCounter;
        }
    }

    
}
