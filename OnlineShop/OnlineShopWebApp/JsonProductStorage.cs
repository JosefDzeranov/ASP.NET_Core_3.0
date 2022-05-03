using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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
        }

        public void DeleteProduct(Product product)
        {
            Products.Remove(product);
            WriteToStorage();
        }


        public void UpdateProduct(Product oldProduct, Product newProduct)
        {
            static void VerifyNull<T>(T TOld, T TNew)
            {
                if (TNew is object)
                {
                   TOld ??= TNew;
                }
                else
                {
                    try
                    {
                        if (Convert.ToDouble(TNew)!=0) TOld = TNew;
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine($"{e} - неозможно привести к double");
                        throw;
                    }
                    
                }
            }
            VerifyNull(oldProduct.Cost, newProduct.Cost);
            VerifyNull(oldProduct.Description, newProduct.Description);
            VerifyNull(oldProduct.Images, newProduct.Images);
            VerifyNull(oldProduct.Length, newProduct.Length);
            VerifyNull(oldProduct.Name, newProduct.Name);
            VerifyNull(oldProduct.Square, newProduct.Square);
            VerifyNull(oldProduct.Width, newProduct.Width);
            WriteToStorage();
        }

        public void AddNewProduct(Product product)
        {
            List<Product> sProducts = new List<Product>(Products.OrderBy(p => p.Id));
            for (int i=0; i < sProducts.Count; i++)
            {
                while (i > 0 && sProducts[i].Id == sProducts[i - 1].Id)
                {
                    Products.Remove(sProducts[i]);
                    sProducts.RemoveAt(i);
                }
            }
            for (int i=0; i< sProducts.Count; i++)
            {
                if (sProducts[i].Id != i)
                {
                    product.Id = i;
                    break;
                }
                if (i == sProducts.Count - 1)
                {
                    product.Id = i + 1;
                    break;
                }
            }
            Products.Add(product);
            WriteToStorage();
        }
    }
}
