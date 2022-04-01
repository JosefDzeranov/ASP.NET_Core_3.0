using OnlineDesignBureauWebApp.Models;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace OnlineDesignBureauWebApp
{
    public class ProductCatalog
    {
        public static List<Product> Products = new List<Product>();
        public static List<int> IdProducts = new List<int>();
        public void CreateNewProduct(string name, decimal cost, string description)
        {
            Products.Add(new Product(IdProduct.GiveMeId(), name, cost, description));
            IdProducts.Add(Products[Products.Count-1].Id);
        }

        public List<Product> GetProducts()
        {
            return Products;
        }
        public void WriteToJson(List<Product> products, string nameFile) 
        {
            File.WriteAllText($"{nameFile}.json", string.Empty);
            for (int i = 0; i < products.Count; i++)
                File.AppendAllText($"{nameFile}.json", JsonConvert.SerializeObject(products[i]));
        }
        public void ReadToJson(string nameFile) 
        {
            Products.Clear();
            JsonTextReader reader = new JsonTextReader(new StreamReader($"{nameFile}.json"));
            reader.SupportMultipleContent = true; //для поддержки чтения нескольких фрагментов содержимого JSON
            while (true)
            {
                if (!reader.Read()) break;
                JsonSerializer serializer = new JsonSerializer();
                Product temp_point = serializer.Deserialize<Product>(reader);
                Products.Add(temp_point);
            }
            reader.Close();
            IdProduct.ReadIdInCatalog(Products); // считываем все id в сохранении
            
        }
        public string GetId(int id)
        {
            foreach (var product in Products)
            {
                if (product.Id == id) 
                    return $"{product.Id}\n{product.Name}\n{product.Cost}\n";
            }
            return $"Продукт с данным id={id} отсутствует";
        }
    }
}
