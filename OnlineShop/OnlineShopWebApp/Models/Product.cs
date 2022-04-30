namespace OnlineShopWebApp.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Cost { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }

        public Product(int id,string name, decimal cost, string description, string imagePath)
        {
            Id = id;

            Name = name;

            Cost = cost;

            Description = description;
            
            ImagePath = imagePath;
        }
    }
}
