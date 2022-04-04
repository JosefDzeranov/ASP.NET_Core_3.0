namespace WebOnlineShop.Models
{
    public class Product
    {
        private int instanceCounter = 1;
        public int Id { get; }
        public string Name { get; }
        public decimal Cost { get; }
        public string Description { get; }

        public Product(string name, decimal cost, string descripton)
        {
            Id = instanceCounter;
            Name = name;
            Cost = cost;
            Description = descripton;

            instanceCounter += 1;
        }

    }
}
