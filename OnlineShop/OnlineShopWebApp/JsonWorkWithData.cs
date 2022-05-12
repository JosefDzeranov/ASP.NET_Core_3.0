using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using OnlineShopWebApp.Interfase;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp
{
    public class JsonWorkWithData:IWorkWithData
    {
        public string Name { get; set; }
        private string repository = "Data";
        private string dataFormat = "json";
        private string nameSave;

        public JsonWorkWithData(string name)
        {
            Name = name;
            nameSave = string.Format($"{repository}/{name}.{dataFormat}"); // repository + "/" + name + dataFormat;
        }
        public string WriteToStorage<T>(List<T> TlistObjects)
        {
            var json = JsonConvert.SerializeObject(TlistObjects, Formatting.Indented);
            File.WriteAllText(nameSave, json);
            return json;
        }

        public List<T> ReadToStorage<T>()
        {
            List<T> TListObjects = new List<T>();
            try
            {
                var json = File.ReadAllText(nameSave);
                TListObjects = JsonConvert.DeserializeObject<List<T>>(json);
            }
            catch (FileNotFoundException)
            {
            }
            return TListObjects;
        }
    }
}
