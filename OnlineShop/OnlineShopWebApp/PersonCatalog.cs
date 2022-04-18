using System.Collections.Generic;
using Newtonsoft.Json;
using System.IO;
using OnlineDesignBureauWebApp;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp
{
    public static class PersonCatalog
    {
        public static List<Person> persons = new List<Person>();
        public static void WriteToJson()
        {
            string nameFile = "list_of_persons";
            string json = JsonConvert.SerializeObject(persons, Formatting.Indented);
            File.WriteAllText($"{nameFile}.json", json);
        }
        public static void ReadToJson()
        {
            string nameFile = "list_of_persons";
            persons.Clear();
            string json = File.ReadAllText($"{nameFile}.json");
            persons = JsonConvert.DeserializeObject<List<Person>>(json);
        }

        public static void AddProductInBaset(int productId, int personId)
        {
            FindPerson(personId).CartList.Add(ProductCatalog.FindProduct(productId));
        }
        public static void DeleteProductInBaset(int productId, int personId)
        {
            FindPerson(personId).CartList.RemoveAt(productId);
        }
        public static Person FindPerson(int personId)
        {
            Person person = persons.Find(x => x.Id == personId);
            return person;
        }
    }

}
