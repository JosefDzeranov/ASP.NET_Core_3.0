using OnlineShopWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OnlineShopWebApp
{
    public class DataStorage
    {
        public Product GetProductId(int id)
        {
            List<Product> productsJson;

            try
            {
                productsJson = ProductsStorage.DeserializeJsonProducts();
            }

            catch (Exception) 
            {
                return null;
            }

            Product result = productsJson.FirstOrDefault(x => x.Id == id);

            return result;
        }
    }
}