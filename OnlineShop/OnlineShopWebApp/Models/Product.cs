namespace OnlineShopWebApp.Models
{
    public class Product
    {
        private static int instanceCounter = 0;
        public int Id { get; set; }
        public string Name { get; }
        public decimal Cost { get; }
        public string Description { get; }

        public Product(int id,string name, decimal cost, string description)
        {
            Id = id;
            Name = name;
            Cost = cost;
            Description = description;

            //instanceCounter += 1;
        }

        //public Product(string name, decimal cost, string description, bool type)
        //{
        //        Id = instanceCounter;
        //        Name = name;
        //        Cost = cost;
        //        Description = description;

        //        instanceCounter += 1;
        //}

        public override string ToString()
        {
            return $"{Id}\n{Name}\n{Cost}\n{Description}";
        }
    }
}
