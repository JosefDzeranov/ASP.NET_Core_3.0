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
        public string WriteToStorage()
        {
            var json = JsonConvert.SerializeObject(Products, Formatting.Indented);
            File.WriteAllText(nameSave, json);
            return json;
        }
        public void ReadToStorage()
        {
            var json = File.ReadAllText(nameSave);
            Products = JsonConvert.DeserializeObject<List<Product>>(json);
        }
        public Product FindProduct(int productId)
        {
            var product = Products.Find(x => x.Id == productId);
            return product;
        }
        public string ReadDataProducts()
        {
            if (Products.Count == 0)
                ReadToStorage();
            var result = "";
            foreach (var product in Products)
            {
                result += product + "\n\n";
            }
            return result;
        }
    }
}
