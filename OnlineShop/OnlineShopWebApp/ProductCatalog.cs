﻿using OnlineDesignBureauWebApp.Models;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace OnlineDesignBureauWebApp
{
    public class ProductCatalog
    {
        public List<Product> products = new List<Product>();
        public string WriteToStorage()
        {
            string nameFile = "projects_for_sale";
            string json = JsonConvert.SerializeObject(products, Formatting.Indented);
            File.WriteAllText($"{nameFile}.json", json);
            return json;
        }
        public void ReadToStorage()
        {
            string nameFile = "projects_for_sale";
            products.Clear();
            string json = File.ReadAllText($"{nameFile}.json");
            products = JsonConvert.DeserializeObject<List<Product>>(json);
        }

        public Product FindProduct(int productId, List<Product> products)
        {
            Product product = products.Find(x => x.Id == productId);
            return product;
        }

        public string ReadDataProducts()
        {
            if (products.Count == 0)
                ReadToStorage();
            var result = "";
            foreach (var product in products)
            {
                result += product + "\n\n";
            }
            return result;
        }
    }
}
