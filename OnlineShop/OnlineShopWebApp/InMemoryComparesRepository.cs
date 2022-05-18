using OnlineShopWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShopWebApp
{
    public class InMemoryComparesRepository : IComparesRepository
    {
        private List<ProductViewModel> productsToCompare = new List<ProductViewModel>();

        public void Add(ProductViewModel product)
        {

            var existingProductToCompare = productsToCompare.FirstOrDefault(x => x.Id == product.Id);
            if (existingProductToCompare == null)
            {
                productsToCompare.Add(product);
            }
        }

        public List<ProductViewModel> GetCompare()
        {
            return productsToCompare;
        }

        public void Clear()
        {
            productsToCompare.Clear();
        }
        public void Delete(ProductViewModel product)
        {
            productsToCompare.Remove(product);
        }
    }
}
