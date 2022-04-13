using System.Collections.Generic;
using Newtonsoft.Json;
using System.IO;
using OnlineDesignBureauWebApp;
using OnlineDesignBureauWebApp.Models;
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

        public static void AddProductInBaset(int id_product, int id_person)
        {
            FindPerson(id_person).BasketList.Add(ProductCatalog.FindProduct(id_product));
        }  
        public static void DeleteProductInBaset(int id_product, int id_person)
        {
            FindPerson(id_person).BasketList.RemoveAt(id_product);
        }
        public static Person FindPerson(int id)
        {
            Person person = persons.Find(x => x.Id == id);
            return person;
        }
    }

}
