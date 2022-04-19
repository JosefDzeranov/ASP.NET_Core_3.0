using System.Collections.Generic;
using Newtonsoft.Json;
using System.IO;
using OnlineDesignBureauWebApp;
using OnlineDesignBureauWebApp.Models;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp
{
    public class PersonCatalog
    {
        private readonly ProductCatalog productCatalog;
        public PersonCatalog(ProductCatalog productCatalog)
        {
            this.productCatalog = productCatalog;
        }

        public List<Person> Persons = new List<Person>();

        public void WriteToJson()
        {
            string nameFile = "list_of_persons";
            string json = JsonConvert.SerializeObject(Persons, Formatting.Indented);
            File.WriteAllText($"{nameFile}.json", json);
        }
        public void ReadToJson()
        {
            string nameFile = "list_of_persons";
            Persons.Clear();
            string json = File.ReadAllText($"{nameFile}.json");
            Persons = JsonConvert.DeserializeObject<List<Person>>(json);
        }

        public void AddProductInCart(int productId, int personId)
        {
            Product product = productCatalog.FindProduct(productId, FindPerson(personId).CartList);
            FindPerson(personId).CartList.Add(product);
        }
        public void DeleteProductInCart(int productId, int personId)
        {
            FindPerson(personId).CartList.RemoveAt(productId);
        }
        public Person FindPerson(int personId)
        {
            Person person = Persons.Find(x => x.Id == personId);
            return person;
        }
    }
}
