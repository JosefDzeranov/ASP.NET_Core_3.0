using Newtonsoft.Json;
using OnlineDesignBureauWebApp.Models;
using OnlineShopWebApp.Interfase;
using OnlineShopWebApp.Models;
using System.Collections.Generic;
using System.IO;

namespace OnlineShopWebApp
{
    public class JsonBuyerStorage : IBuyerStorage
    {
        private const string buyersFileName = "list_of_buyers.json";

        private List<Buyer> buyers = new List<Buyer>();

        public JsonBuyerStorage()
        {
            ReadToStorage();
        }

        public void AddProductInCart(Product product, int buyerId)
        {
            var buyer = FindBuyer(buyerId);
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

        public void CleenCart(int buyerId)
        {
            var buyer = FindBuyer(buyerId);
            buyer.ClearCart();
            WriteToStorage();
        }
        public Buyer FindBuyer(int personId)
        {
            var buyer = buyers.Find(x => x.Id == personId);
            return buyer;
        }

        public void ReportTransaction(int buyerId)
        {
            var buyer = FindBuyer(buyerId);
            buyer.ReportTransaction();
            WriteToStorage();
        }

        private void WriteToStorage()
        {
            var json = JsonConvert.SerializeObject(buyers, Formatting.Indented);
            File.WriteAllText(buyersFileName, json);
        }

        private void ReadToStorage()
        {
            var json = File.ReadAllText(buyersFileName);
            buyers = JsonConvert.DeserializeObject<List<Buyer>>(json);
        }
    }
}
