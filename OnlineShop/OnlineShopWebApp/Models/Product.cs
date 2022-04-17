namespace OnlineShopWebApp.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; }
        public decimal Cost { get; }
        public string Description { get; }
        public string ImagePath { get; }

        public Product(int id, string name, decimal cost, string description, string imagePath)
        {
            Id = id;

            Name = name;

            Cost = cost;

            Description = description;
            
            ImagePath = imagePath;
        }


        public override string ToString()
        {
            return $"{Id}\n{Name}\n{Cost}\n{Description}\n{ImagePath}";
        }
    }
}
