using Newtonsoft.Json;
using OnlineDesignBureauWebApp.Models;
using OnlineShopWebApp.Interfase;
using OnlineShopWebApp.Models;
using System.Collections.Generic;
using System.IO;

namespace OnlineShopWebApp
{
    public class JsonBuyerStorage:IBuyerStorage
    {
        private IProductStorage productStorage { get; }
        public List<Buyer> Buyers { get; set; } = new List<Buyer>();
        string nameSave = "list_of_buyers";
        public void WriteToStorage()
        {
            var json = JsonConvert.SerializeObject(Buyers, Formatting.Indented);
            File.WriteAllText($"{nameSave}.json", json);
        }
        public void ReadToStorage()
        {
            Buyers.Clear();
            var json = File.ReadAllText($"{nameSave}.json");
            Buyers = JsonConvert.DeserializeObject<List<Buyer>>(json);
        }
        public void AddProductInCart(int productId, int personId)
        {
            var products = productStorage.Products;
            var product = productStorage.FindProduct(productId, products);
            FindBuyer(personId).CartList.Add(product);
            WriteToStorage();
        }
        public void DeleteProductInCart(int productId, int personId)
        {
            FindBuyer(personId).CartList.RemoveAt(productId);
            WriteToStorage();
        }
        public Buyer FindBuyer(int personId)
        {
            var buyer = Buyers.Find(x => x.Id == personId);
            return buyer;
        }
    }
}
