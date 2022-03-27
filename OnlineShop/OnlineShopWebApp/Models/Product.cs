namespace OnlineShopWebApp.Models
{
    public class Product
    {

        public string Id { get;}
        public string Name { get;}
        public string Cost { get;}
        public string Description { get; set; }

        public Product(string id, string name, string cost)
        {
            this.Id = id;
            this.Name = name;
            this.Cost = cost;
           
        }
        
    }
}
