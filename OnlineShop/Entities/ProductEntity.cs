using System.Collections.Generic;

namespace Entities
{
    public class ProductEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Cost { get; set; }
        public string Description { get; set; }
        public string ImgPath { get; set; }
        public List<CartItemEntity> CartItems { get; set; }
        public int AmountInDb { get; set; }

        public ProductEntity(int id, string name, decimal cost, string description, string imgPath, int amountInDb)
        {
            Id = id;
            Name = name;
            Cost = cost;
            Description = description;
            ImgPath = imgPath;
            AmountInDb = amountInDb;
        }

        public ProductEntity() { }
    }
}
