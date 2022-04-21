namespace OnlineShopWebApp.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Image { get; set; }
        public string Name { get; set; }
        public decimal Cost { get; set; }
        public string Description { get; set; }

        public Product () { } // Empty ctor for XML serializing.
        public Product(int id, string image, string name, decimal cost, string description)
        {
            Id = id;
            Image = image;
            Name = name;
            Cost = cost;
            Description = description;
        }
    }
}
