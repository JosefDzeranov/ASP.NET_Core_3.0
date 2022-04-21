namespace OnlineShopWebApp.Models
{
    public class Product
    {
        private static int CurrentId = 1;
        public int Id { get;}
        public string Name { get; set; }
        public decimal Cost { get; set; }
        public string Description { get; set; }
        public string ImgPath { get; set; }
        public Product(string name, decimal cost, string description, string imgPath)
        {
            this.Id = CurrentId;
            this.Name = name;
            this.Cost = cost;
            this.Description = description;
            this.ImgPath = imgPath;
           CurrentId++;
        }
        
    }
}
