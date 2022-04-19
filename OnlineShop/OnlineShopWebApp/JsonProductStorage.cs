using OnlineDesignBureauWebApp.Models;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using OnlineShopWebApp.Interfase;

namespace OnlineDesignBureauWebApp
{
    public class JsonProductStorage:IProductStorage
    {
        public List<Product> Products { get; set; } = new List<Product>();
        string nameSave = "projects_for_sale";

        public string WriteToStorage()
        {
            string json = JsonConvert.SerializeObject(Products, Formatting.Indented);
            File.WriteAllText($"{nameSave}.json", json);
            return json;
        }
        public void ReadToStorage()
        {
            Products.Clear();
            string json = File.ReadAllText($"{nameSave}.json");
            Products = JsonConvert.DeserializeObject<List<Product>>(json);
        }

        public Product FindProduct(int productId, List<Product> products)
        {
            Product product = products.Find(x => x.Id == productId);
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
