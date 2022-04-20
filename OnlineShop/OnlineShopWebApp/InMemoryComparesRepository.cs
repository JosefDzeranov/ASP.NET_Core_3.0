using OnlineShopWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShopWebApp
{
    public class InMemoryComparesRepozitory : IComparesRepository
    {
        private List<Product> productsToCompare = new List<Product>();

        public void Add(Product product)
        {

            var existingProductToCompare = productsToCompare.FirstOrDefault(x => x.Id == product.Id);
            if (existingProductToCompare == null)
            {
                productsToCompare.Add(product);
            }
        }

        public List<Product> GetCompare()
        {
            return productsToCompare;
        }

        public void Clear()
        {
            productsToCompare.Clear();
        }
        public void Delete(int id)
        {
            var existingProductToCompare = productsToCompare.FirstOrDefault(x => x.Id == idd);
            productsToCompare.Remove(existingProductToCompare);
        }
    }
}
