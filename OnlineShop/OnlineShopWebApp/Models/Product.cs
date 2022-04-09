
namespace OnlineShopWebApp.Models
{
    public class Product
    {
        private static int inctanceCounter = 0;

        public int Id { get; }
        public string Name { get;}
        public decimal Cost { get;}
        public string Description { get; }
        public string ImagePath { get; }

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
