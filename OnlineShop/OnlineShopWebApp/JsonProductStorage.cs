using OnlineShopWebApp.Interfase;
using OnlineShopWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OnlineShopWebApp
{
    public class JsonProductStorage : IProductStorage
    {
        public List<Product> Products { get; set; }
        private const string nameSave = "projects_for_sale";
        public IWorkWithData JsonStorage { get; set; } = new JsonWorkWithData(nameSave);
        public JsonProductStorage()
        {
            Products = JsonStorage.ReadToStorage<Product>();
        }

        public Product FindProduct(Guid productId)
        {
            var product = Products.FirstOrDefault(x => x.Id == productId);
            return product;
        }

        public void DeleteProduct(Product product)
        {
            Products.Remove(product);
            JsonStorage.WriteToStorage(Products);
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
            JsonStorage.WriteToStorage(Products);
        }
        public void AddNewProduct(Product product)
        {
            Products.Add(product);
            JsonStorage.WriteToStorage(Products);
        }

    }
}
