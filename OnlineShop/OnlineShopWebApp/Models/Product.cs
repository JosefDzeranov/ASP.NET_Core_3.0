namespace OnlineShopWebApp.Services
{
    public class Product
    {

        public int Id { get;}
        public string Name { get; set; }
        public decimal Cost { get; set; }
        public string Description { get; set; }
        public string ImgPath { get; set; }
        public Product(int id, string name, decimal cost, string description, string imgPath)
        {
            this.Id = id;
            this.Name = name;
            this.Cost = cost;
            this.Description = description;
            this.ImgPath = imgPath;
           
        }
        
    }
}
