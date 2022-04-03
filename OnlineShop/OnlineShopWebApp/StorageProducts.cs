using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace OnlineShopWebApp.Models
{
    public class StorageProducts
    {

        private static List<Product> products = new List<Product>()
        {
            new Product("Составление документов, исков в суд", 5000, "Составление и оформление документов для подачи в суд"),
            new Product("Составление документов для регистрации/банкротства ЮЛ", 4000, "Составление документов для регистрации/банкротства ЮЛ"),
            new Product("Сопровождение и ведение гражданского дела в суде", 6000, "Сопровождение и ведение гражданского дела в суде"),
            new Product("Консультация по вопросам", 3000, "Консультация по вопросам"),
            new Product("Анализ документов и договоров", 3000, "Правовая экспертиза документов и договоров"),
        };

        public static string ShowProducts()
        {
            string currentFile = @"Models\Products.json";
            if (!File.Exists(currentFile))
            {
                string json3 = JsonConvert.SerializeObject(products, Formatting.Indented);
                File.WriteAllText(@"Models\Products.json", json3);
            }

            List<Product> productsJson = DeserializeJsonProducts();

            string output = string.Empty;
            foreach (var product in productsJson)
            {
                output += $"{product.Id}\n{product.Cost}\n{product.Description}\n\n";
            }
            return output;
        }

        /// <summary>
        /// получить товар
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static Product TryGetProduct (int id)
        {
            List<Product> productsJson = DeserializeJsonProducts();

            return productsJson.FirstOrDefault(x => x.Id == id);
        }

        /// <summary>
        /// Валидация JSON файла
        /// </summary>
        /// <param name="strInput"></param>
        /// <returns></returns>
        private static bool IsValidJson(string strInput)
        {
            if (string.IsNullOrWhiteSpace(strInput))
            {
                return false;
            }
            strInput = strInput.Trim();

            if ((strInput.StartsWith("{") && strInput.EndsWith("}")) /*For object */ || (strInput.StartsWith("[") && strInput.EndsWith("]"))) /*For array*/
            {
                try
                {
                    var obj = JToken.Parse(strInput);
                    return true;
                }
                catch (JsonReaderException)
                {
                    return false;
                }
                catch (Exception)
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Десериализация из Json
        /// </summary>
        /// <returns></returns>
        public static List<Product> DeserializeJsonProducts()
        {
            string currentFile = @"Models\Products.json";

            var strFromReq = new StreamReader(currentFile).ReadToEnd();
            var obj = JsonConvert.DeserializeObject(strFromReq).ToString();

            List<Product> productsJson = JsonConvert.DeserializeObject<List<Product>>(obj);

            if (IsValidJson(obj))
            {
                return productsJson;
            }
            else
                return null;
        }

    }
}
