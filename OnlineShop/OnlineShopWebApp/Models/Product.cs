namespace OnlineShopWebApp.Models
{
    public class Product
    {
        private static int instanceCounter =0;

        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Cost { get; set; }  
        
        public string Description { get; set; }

        public string ImagePath { get; set; }

		public Product()
		{
        }

		public Product(string name, decimal cost, string description, string imagePath)
		{
            Id = GetNextId();
			Name = name;
			Cost = cost;
			Description = description;
            ImagePath = imagePath;
		}

		public override string ToString()
        {
            return $"Id {this.Id}\nName {this.Name}\nCost {this.Cost}\nDescription {this.Description}\n\n";
        }

        public static int GetNextId()
        {
            instanceCounter += 1;

            return instanceCounter;
        }
    }

    
}
