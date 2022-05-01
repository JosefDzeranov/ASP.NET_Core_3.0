using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using OnlineShopWebApp.Interfase;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp
{
    public class JsonProductStorage:IProductStorage
    {
        public List<Product> Products { get; set; } = new List<Product>();
        string nameSave = "Data/projects_for_sale.json";

        public JsonProductStorage()
        {
            ReadToStorage();
        }

        public Product FindProduct(int productId)
        {
            var product = Products.Find(x => x.Id == productId);
            return product;
        }

        public string WriteToStorage()
        {
            var json = JsonConvert.SerializeObject(Products, Formatting.Indented);
            File.WriteAllText(nameSave, json);
            return json;
        }

        private void ReadToStorage()
        {
            var json = File.ReadAllText(nameSave);
            Products = JsonConvert.DeserializeObject<List<Product>>(json);
        }

        public void DeleteProduct(Product product, int userId)
        {

        }

        public void UpdateProduct(Product oldProduct, Product newProduct, int userId)
        {

        }

        public void AddNewProduct(Product product, int userId)
        {

        }
    }
}
