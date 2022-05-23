using System.IO;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;
using OnlineShopWebApp.Interfase;

namespace OnlineShopWebApp
{
    public class JsonWorkWithData : IWorkWithData
    {
        public string Name { get; set; }
        private string dataFormat = "json";
        private string nameSave;

        public JsonWorkWithData(string name)
        {
            Name = name;
            nameSave = string.Format($"Data/{name}.{dataFormat}");
        }
        public void Write<T>(T TObject)
        {
            var options = new JsonSerializerOptions
            {
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic),
                WriteIndented = true
            };
            var json = JsonSerializer.Serialize(TObject, options);
            File.WriteAllText(nameSave, json);
        }

        public T Read<T>() where T : new()
        {
            T TObject = new T();
            try
            {
                var json = File.ReadAllText(nameSave);
                TObject = JsonSerializer.Deserialize<T>(json);
            }
            catch (FileNotFoundException)
            {
            }
            return TObject;
        }
    }
}
