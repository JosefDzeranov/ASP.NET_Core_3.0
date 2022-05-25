using System;
using System.ComponentModel.DataAnnotations;

namespace OnlineShopWebApp.Models
{
    public class Product
    {
        private static int uniId = 1;
        public int Id { get; set; }
        [Required(ErrorMessage = "Поле названия незаполнено!")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Поле цены незаполнено!")]
        public decimal Price { get; set; }
        [Required(ErrorMessage = "Поле описания незаполнено!")]
        public string Description { get; set; }
        public string ImagesPath { get; set; }
        public string GPU { get; set; }
        public string MemoryType { get; set; }
        public string MemoryCount { get; set; }
        public string GpuGhz { get; set; }
        public string TurboGpuGhz { get; set; }

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
