using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace OnlineShopWebApp.Models
{
    public class StorageProducts
    {
        /// <summary>
        /// Список услуг
        /// </summary>
        private static readonly List<Product> products = new List<Product>()
        {
            new Product(1, "Составление документов, исков в суд", 5000, "Услуга позволяет сформировать документы для подачи в суд"),
            new Product(2, "Составление документов для регистрации/банкротства ЮЛ", 4000, "Услуга позволяет сформировать документы для регистрации/банкротства ЮЛ"),
            new Product(3, "Сопровождение и ведение гражданского дела в суде", 6000, "Услуга позволяет подключить специалиста для сопровождения и ведения гражданского дела в суде"),
            new Product(4, "Консультация по вопросам", 3000, "Консультация по разным вопросам, не более 1 часа"),
            new Product(5, "Анализ документов и договоров", 3000, "Услуга позволяет провести правовую экспертизу документов и договоров"),
        };


        public static string ShowProducts()
        {
            string currentFile = @"Models\Products.json";
            if (!File.Exists(currentFile))
            {
                //string json2 = JsonSerializer.Serialize(products); -- данная библиотека не очень красиво форматирует
                string json3 = JsonConvert.SerializeObject(products, Formatting.Indented);
                File.WriteAllText(@"Models\Products.json", json3);
            }

            List<Product> productsJson = DeserializeProducts();

            string output = string.Empty;
            foreach (var product in productsJson)
            {
                output += $"{product.Id}\n{product.Cost}\n{product.Description}\n\n";
            }
            return output;
        }

        public static Product TryGetProduct(int id)
        {
            List<Product> productsJson;

            try
            {
                productsJson = DeserializeProducts();
            }
            catch (Exception)
            {
                return null;
            }

            return productsJson.FirstOrDefault(x => x.Id == id);
        }

        public static List<Product> DeserializeProducts()
        {
            string currentFile = @"Models\Products.json";

            var strFromReq = new StreamReader(currentFile).ReadToEnd();
            var obj = JsonConvert.DeserializeObject(strFromReq);

            List<Product> productsJson = JsonConvert.DeserializeObject<List<Product>>((string)obj);

            return productsJson;
        }
    }
}
