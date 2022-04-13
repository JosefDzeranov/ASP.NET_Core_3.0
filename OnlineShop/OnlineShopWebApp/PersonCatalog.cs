using System.Collections.Generic;
using Newtonsoft.Json;
using System.IO;
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
        public static Person FindPerson(int id)
        {
            Person person = persons.Find(x => x.Id == id);
            return person;
        }
    }

}
