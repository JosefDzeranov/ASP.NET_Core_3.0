using OnlineDesignBureauWebApp.Models;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using OnlineShopWebApp.Interfase;

namespace OnlineDesignBureauWebApp
{
    public class JsonProductStorage : IProductStorage
    {
        public List<Product> Products { get; set; } = new List<Product>();
        string nameSave = "projects_for_sale.json";
        public JsonProductStorage()
        {
            ReadToStorage();
        }
        public string WriteToStorage()
        {
            var json = JsonConvert.SerializeObject(Products, Formatting.Indented);
            File.WriteAllText($"{nameSave}.json", json);
            return json;
        }
        public void ReadToStorage()
        {
            var json = File.ReadAllText(nameSave);
            Products = JsonConvert.DeserializeObject<List<Product>>(json);
        }
        public Product FindProduct(int productId)
        {
            return Products.Find(x => x.Id == productId);
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
