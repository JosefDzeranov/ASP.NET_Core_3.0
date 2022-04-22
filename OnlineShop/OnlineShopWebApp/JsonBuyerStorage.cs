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
        public void AddProductInCart(int productId, int buyerId, IProductStorage productStorage)
        {
            var products = productStorage.Products;
            var product = productStorage.FindProduct(productId, products);
            var buyer = FindBuyer(buyerId);
            buyer.CartList=buyer.SumDuplicates(product);
            WriteToStorage();
        }
        public void DeleteProductInCart(int productId, int buyerId)
        {
            var cart = FindBuyer(buyerId).CartList;
            for (int i = 0; i < cart.Count; i++)
            {
                cart.RemoveAt(i);
            }
            WriteToStorage();
        }

        public void ReduceDuplicateProductCart(int productId, int buyerId)
        {
            var cart = FindBuyer(buyerId).CartList;
            for (int i = 0; i < cart.Count; i++)
            {
                if (productId == cart[i].Product.Id)
                {
                    if (cart[i].NumDuplicates > 1)
                    {
                        cart[i].NumDuplicates--;
                    }
                    else
                    {
                        cart.RemoveAt(i);
                    }
                }
            }
            WriteToStorage();
        }
        public void CleenCart(int buyerId)
        {
            FindBuyer(buyerId).CartList.Clear();
            WriteToStorage();
        }
        public Buyer FindBuyer(int buyerId)
        {
            var buyer = Buyers.Find(x => x.Id == buyerId);
            return buyer;
        }
    }
}
