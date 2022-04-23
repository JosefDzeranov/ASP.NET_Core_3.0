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
        public Category CategoryName{ get; set; }

        public Product()
        {
            this.Id = CurrentId;
            CurrentId++;
        }

        public enum Category
        {
            Фантастика,
            Приключения,
            Классика,
            Детектив
        }
    }
}
