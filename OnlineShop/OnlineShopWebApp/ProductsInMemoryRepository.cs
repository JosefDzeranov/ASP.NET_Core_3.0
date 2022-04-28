using Newtonsoft.Json;
using OnlineShopWebApp.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Unicode;

namespace OnlineShopWebApp
{
    public class ProductsInMemoryRepository : IProductBase
    {
        System.Text.Json.JsonSerializerOptions jsonOption = new System.Text.Json.JsonSerializerOptions()
        {
            Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic),
            WriteIndented = true
        };
        

        public int NextProductId()
        {
            var maxIdProduct = AllProducts().Select(x => x.Id).Max();
            return maxIdProduct + 1;

        }
        public IEnumerable<Product> AllProducts()
        {
            using (StreamReader r = new StreamReader("Models/products.json", Encoding.UTF8))
            {
                return JsonConvert.DeserializeObject<List<Product>>(r.ReadToEnd());
            }
        }

        public Product TryGetById(int productId)
        {
            return AllProducts().FirstOrDefault(x => x.Id == productId);
        }

        public void Add(Product product)
        {
            product.Id = NextProductId();
            product.ImgPath = "/img/Silk_green.jpg";

            var newListOfProducts = AllProducts().Append(product);
            var json = System.Text.Json.JsonSerializer.Serialize(newListOfProducts, jsonOption);
            
            File.WriteAllText("Models/products.json", json);
        }

        public void Delete(int productId)
        {
            var newListOfProducts = AllProducts().Where(x => x.Id != productId);
            var json = System.Text.Json.JsonSerializer.Serialize(newListOfProducts, jsonOption);
            File.WriteAllText("Models/products.json", json);
        }

        public void Edit(int productId, Product product)
        {
            Delete(productId);
            Add(product);
        }
    }
}
