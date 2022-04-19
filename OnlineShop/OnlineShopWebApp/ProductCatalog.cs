using OnlineDesignBureauWebApp.Models;
using System.Collections.Generic;
using System.IO;
using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json;
using OnlineShopWebApp.Interfase;

namespace OnlineDesignBureauWebApp
{
    public class ProductCatalog : IProductMemoryStorage
    {
        public List<Product> Products = new List<Product>();

        public string WriteToStorage()
        {
            string nameFile = "projects_for_sale";
            string json = JsonConvert.SerializeObject(Products, Formatting.Indented);
            File.WriteAllText($"{nameFile}.json", json);
            return json;
        }
        public void ReadToStorage()
        {
            string nameFile = "projects_for_sale";
            Products.Clear();
            string json = File.ReadAllText($"{nameFile}.json");
            Products = JsonConvert.DeserializeObject<List<Product>>(json);
        }

        public Product FindProduct(int productId, List<Product> products)
        {
            Product product = Products.Find(x => x.Id == productId);
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
