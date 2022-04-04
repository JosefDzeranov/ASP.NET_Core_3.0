

namespace OnlineDesignBureauWebApp.Models
{
    public class Product
    {
        public int Id { get; }
        public string Name { get; set; }
        public decimal Cost { get; set; }
        public string Description { get; set; }
        public Product(int id, string name, decimal cost, string description)
        {
            Id = id;
            Name = name;
            Cost = cost;
            Description = description;
        }
        public override string ToString()
        {
            return $"{Id}\n{Name}\n{Cost}";
        }
    }
}
