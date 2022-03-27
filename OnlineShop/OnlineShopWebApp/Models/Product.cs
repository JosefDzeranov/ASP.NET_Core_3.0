namespace OnlineShopWebApp.Models
{
    public class Product
    {

        public int Id { get;}
        public string Name { get;}
        public decimal Cost { get;}
        public string Description { get; set; }

        public Product(int id, string name, decimal cost)
        {
            this.Id = id;
            this.Name = name;
            this.Cost = cost;
            Description = "";
        }
        
    }
}
