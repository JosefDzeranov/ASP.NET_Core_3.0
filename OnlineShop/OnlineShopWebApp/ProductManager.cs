using OnlineShopWebApp.Interfase;
using OnlineShopWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OnlineShopWebApp
{
    public class ProductManager : IProductManager
    {
        public List<Product> Products { get; set; }
        private const string nameSave = "projects_for_sale";
        private IWorkWithData JsonStorage { get; } = new JsonWorkWithData(nameSave);
        public ProductManager()
        {
            Products = JsonStorage.Read<List<Product>>();
        }

        public Product Find(Guid productId)
        {
            var product = Products.FirstOrDefault(x => x.Id == productId);
            return product;
        }

        public void Delete(Product product)
        {
            Products.Remove(product);
            JsonStorage.Write(Products);
        }
        public void UpdateProduct(Product newProduct)
        {
            var oldProduct = Find(newProduct.Id);
            oldProduct.Cost = newProduct.Cost;
            oldProduct.Description = newProduct.Description;
            oldProduct.Images[0] = newProduct.Images[0];
            oldProduct.Length = newProduct.Length;
            oldProduct.CodeNumber = newProduct.CodeNumber;
            oldProduct.Square = newProduct.Square;
            oldProduct.Width = newProduct.Width;
            JsonStorage.Write(Products);
        }
        public void AddNew(Product product)
        {
            Products.Add(product);
            JsonStorage.Write(Products);
        }

    }
}
