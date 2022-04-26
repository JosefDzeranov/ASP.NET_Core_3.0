
namespace OnlineShopWebApp.Models
{
    public class Product
    {
        private static int inctanceCounter = 0;
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Cost { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }

        public Product(string name, decimal cost, string description, string imagePath)
        {
            Id = inctanceCounter;
            Name = name;
            Cost = cost;
            Description = description;

            inctanceCounter += 1;
            ImagePath = imagePath;
        }

        public override string ToString()
        {
            return $"{Id}\n{Name}\n{Cost}";
        }
    }
}
