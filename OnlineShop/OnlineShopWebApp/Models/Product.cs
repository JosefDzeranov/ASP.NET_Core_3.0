using System.ComponentModel.DataAnnotations;

namespace OnlineShopWebApp.Models
{
    public class Product
    {
        private static int inctanceCounter = 0;
        public int Id { get; set;}

        [Required]
        public string Name { get; set;}

        [Range(500,10000, ErrorMessage = "Cost should be between 500 and 10000 Rub")]
        [DataType(DataType.Currency, ErrorMessage ="Number")]
        public decimal Cost { get; set;}

        [Required]
        public string Description { get; set;}
        public string ImagePath { get; set;}

        public Product()
        {
            Id = inctanceCounter;
            inctanceCounter += 1;
        }

        public Product(string name, decimal cost, string description, string imagePath):this()
        {
            Name = name;
            Cost = cost;
            Description = description;
            ImagePath = imagePath;
        }

        public override string ToString()
        {
            return $"{Id}\n{Name}\n{Cost}";
        }
    }
}
