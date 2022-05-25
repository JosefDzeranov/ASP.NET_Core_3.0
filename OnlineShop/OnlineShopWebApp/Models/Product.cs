using System;

namespace OnlineShopWebApp.Models
{
    public class Product
    {
        private static int uniId = 1;
        public int Id { get; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public string ImagesPath { get; set; }
        public string GPU { get; }
        public string MemoryType { get; }
        public string MemoryCount { get; }
        public string GpuGhz { get; }
        public string TurboGpuGhz { get; }

        public Product(string name, decimal price, string description, string imagespath = null)
        {
            Id = uniId;
            Name = name;
            Price = price;
            Description = description;
            GPU = gpu;
            MemoryType = memorytype;
            MemoryCount = memorycount;
            GpuGhz = gpughz;
            TurboGpuGhz = turgpughz;

            uniId += 1;
            ImagesPath = imagespath;
        }

        public override string ToString()
        {
            return $"{Id}\n{Name}\n{Price}";
        }
    }
}
