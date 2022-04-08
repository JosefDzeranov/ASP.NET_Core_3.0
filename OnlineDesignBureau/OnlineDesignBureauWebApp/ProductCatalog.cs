using OnlineDesignBureauWebApp.Models;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace OnlineDesignBureauWebApp
{
    public class ProductCatalog
    {
        public static List<Product> products = new List<Product>();

        public string WriteToJson(string nameFile)
        {
            var json = JsonConvert.SerializeObject(products, Formatting.Indented);
            File.WriteAllText($"{nameFile}.json", json);
            return json;
        }
        public void ReadToJson(string nameFile)
        {
            products.Clear();
            var json = File.ReadAllText($"{nameFile}.json");
            products = JsonConvert.DeserializeObject<List<Product>>(json);
        }

        public string ReadDataProducts()
        {
            if (products.Count == 0)
                ReadToJson("projects_for_sale");
            var result = "";
            foreach (var product in products)
            {
                result += product + "\n\n";
            }
            return result;
        }
    }
}
