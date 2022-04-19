using System.Collections.Generic;
using Newtonsoft.Json;
using System.IO;
using OnlineDesignBureauWebApp;
using OnlineDesignBureauWebApp.Models;
using OnlineShopWebApp.Interfase;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp
{
    public class JsonBuyerStorage:IBuyerStorage
    {

        public List<Buyer> Persons { get; set; } = new List<Buyer>();

        public void WriteToStorage()
        {
            string nameFile = "list_of_persons";
            string json = JsonConvert.SerializeObject(Persons, Formatting.Indented);
            File.WriteAllText($"{nameFile}.json", json);
        }
        public void ReadToStorage()
        {
            string nameFile = "list_of_persons";
            Persons.Clear();
            string json = File.ReadAllText($"{nameFile}.json");
            Persons = JsonConvert.DeserializeObject<List<Buyer>>(json);
        }

        public void AddProductInCart(int productId, int personId, IProductStorage productCatalog)
        {
            Product product = productCatalog.FindProduct(productId, productCatalog.Products);
            FindPerson(personId).CartList.Add(product);
        }
        public void DeleteProductInCart(int productId, int personId)
        {
            FindPerson(personId).CartList.RemoveAt(productId);
        }
        public Buyer FindPerson(int personId)
        {
            Buyer buyer = Persons.Find(x => x.Id == personId);
            return buyer;
        }
    }
}
