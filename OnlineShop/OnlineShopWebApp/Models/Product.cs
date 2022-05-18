using System;
using System.ComponentModel.DataAnnotations;

namespace OnlineShopWebApp.Models
{
    public class Product
    {
        private static int uniId = 1;
        public int Id { get; }
        [Required(ErrorMessage = "Поле названия незаполнено!")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Поле цены незаполнено!")]
        public decimal Price { get; set; }
        [Required(ErrorMessage = "Поле описания незаполнено!")]
        public string Description { get; set; }
        public string ImagesPath { get; set; }
        public string GPU { get; }
        public string MemoryType { get; }
        public string MemoryCount { get; }
        public string GpuGhz { get; }
        public string TurboGpuGhz { get; }

        public Product()
        {
            Id = uniId;
            uniId += 1;
        }

        public Product(string name, decimal price, string description, string gpu, string memorytype, string memorycount,
            string gpughz, string turgpughz, string imagespath = null): this()
        {
            Name = name;
            Price = price;
            Description = description;
            GPU = gpu;
            MemoryType = memorytype;
            MemoryCount = memorycount;
            GpuGhz = gpughz;
            TurboGpuGhz = turgpughz;

            ImagesPath = imagespath;
        }

        public override string ToString()
        {
            return $"{Id}\n{Name}\n{Price}";
        }
    }
}
