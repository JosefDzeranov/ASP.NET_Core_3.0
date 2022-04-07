namespace OnlineShopWebApp.Models
{
    public class Cart
    {
        public int Id { get; set; }
        public string Name { get; }
        public int Count { get; set; }
        public decimal Cost { get; }


        public Cart(int id, string name, int count, decimal cost)
        {
            Id = id;

            Name = name;

            Count = count;

            Cost = cost;
        }
    }
}
