
namespace OnlineShopWebApp.Models
{
    public class Product
    {
        private static int inctanceCounter = 0;

        public int Id { get; }
        public string Name { get;}
        public decimal Cost { get;}
        public string Description { get; }

        public Product(string name, decimal cost, string description)
        {
            Id = inctanceCounter;
            Name = name;
            Cost = cost;
            Description = description;

            inctanceCounter += 1;
        }

        public override string ToString()
        {
            return $"{Id}\n{Name}\n{Cost}";
        }
    }
}
