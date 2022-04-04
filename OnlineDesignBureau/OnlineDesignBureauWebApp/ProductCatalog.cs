﻿using OnlineDesignBureauWebApp.Models;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace OnlineDesignBureauWebApp
{
    public class ProductCatalog
    {
        public static List<Product> products = new List<Product>();
        public List<Product> GetProducts()
        {
            return products;
        }
        public string WriteToJson(string nameFile)
        {
            string json = JsonConvert.SerializeObject(products, Formatting.Indented);
            File.WriteAllText($"{nameFile}.json", json);
            return json;
        }
        public void ReadToJson(string nameFile)
        {
            products.Clear();
            string json = File.ReadAllText($"{nameFile}.json");
            products = JsonConvert.DeserializeObject<List<Product>>(json);
        }

        public string ReadDataProducts()
        {
            if (GetProducts().Count == 0)
                ReadToJson("projects_for_sale");
            var result = "";
            foreach (var product in GetProducts())
            {
                result += product + "\n\n";
            }
            return result;
        }

    }
}
