using Newtonsoft.Json;
using OnlineShopWebApp.Interfase;
using OnlineShopWebApp.Models;
using System.Collections.Generic;
using System.IO;

namespace OnlineShopWebApp
{
    public class JsonProductStorage:IProductStorage
    {
        private int instanceCounter { get; set; }
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

            List<int> idProducts = new List<int>();
            foreach (var prod in Products)
            {
                idProducts.Add(prod.Id);
            }
            idProducts.Sort();
            if (instanceCounter <= idProducts[^1])
            {
                instanceCounter = idProducts[^1];
            }
        }

        public void DeleteProduct(Product product)
        {
            Products.Remove(product);
            WriteToStorage();
        }


        public void UpdateProduct(Product newProduct)
        {
            var oldProduct = FindProduct(newProduct.Id);
            oldProduct.Cost = newProduct.Cost;
            oldProduct.Description = newProduct.Description;
            oldProduct.Images[0] = newProduct.Images[0];
            oldProduct.Length = newProduct.Length;
            oldProduct.CodeNumber = newProduct.CodeNumber;
            oldProduct.Square = newProduct.Square;
            oldProduct.Width = newProduct.Width;
            WriteToStorage();
        }

        public void AddNewProduct(Product product)
        {
            product.Id = assignId();
            Products.Add(product);
            WriteToStorage();
        }
        

        public int assignId()
        {
            instanceCounter++;
            return instanceCounter;
        }
    }
}
