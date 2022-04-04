using OnlineDesignBureauWebApp.Models;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace OnlineDesignBureauWebApp
{
    public class ProductCatalog
    {
        private static List<Product> products = new List<Product>();
        private static List<int> productsIds = new List<int>();
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
            ReadIdInCatalog(products); 
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
        public string GetProduct(int id)
        {
            foreach (var product in products)
            {
                if (product.Id == id)
                    return $"{product.Id}\n{product.Name}\n{product.Cost}\n";
            }
            return $"Продукт с данным id={id} отсутствует";
        }
        public static void ReadIdInCatalog(List<Product> catalogProducts) //считываем все id из каталога
        {
            foreach (var product in catalogProducts)
            {
                productsIds.Add(product.Id);
            }
        }
    }
}
