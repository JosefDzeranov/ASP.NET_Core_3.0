using Newtonsoft.Json;
using OnlineShopWebApp.Interfase;
using OnlineShopWebApp.Models;
using System.Collections.Generic;
using System.IO;

namespace OnlineShopWebApp
{
    public class JsonBuyerStorage:IBuyerStorage
    {
        private const string buyersFileName = "Data/list_of_buyers.json";
        private IProductStorage productStorage;

        public List<Buyer> Buyers { get; set; } = new List<Buyer>();

        public JsonBuyerStorage()
        {
            ReadToStorage();
        }

        public void WriteToStorage()
        {
            var json = JsonConvert.SerializeObject(Buyers, Formatting.Indented);
            File.WriteAllText(buyersFileName, json);
        }

        public void ReadToStorage()
        {
            var json = File.ReadAllText(buyersFileName);
            Buyers = JsonConvert.DeserializeObject<List<Buyer>>(json);
        }
        
        public void AddProductInCart(int productId, int buyerId)
        {
            var buyer = FindBuyer(buyerId);
            var product = productStorage.FindProduct(productId);
            buyer.AddProductInCart(product);
            WriteToStorage();
        }

        public void DeleteProductInCart(int productId, int buyerId)
        {
            var buyer = FindBuyer(buyerId);
            buyer.DeleteProductInCart(productId);
            WriteToStorage();
        }

        public void ReduceDuplicateProductCart(int productId, int buyerId)
        {
            var buyer = FindBuyer(buyerId);
            buyer.ReduceDuplicateProductCart(productId);
            WriteToStorage();
        }

        public void ClearCart(int buyerId)
        {
            FindBuyer(buyerId).Cart.Clear();
            WriteToStorage();
        }
        public Buyer FindBuyer(int buyerId)
        {
            var buyer = Buyers.Find(x => x.Id == buyerId);
            return buyer;
        }
    }
}
