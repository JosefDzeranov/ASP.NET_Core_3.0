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

        /// <summary>
        /// получить описание товара
        /// </summary>
        /// <returns></returns>
        public static Product ShowProducts()
        {
            string currentFile = @"Models\Products.json";
            if (!File.Exists(currentFile))
            {
                //string json2 = JsonSerializer.Serialize(products); -- данная библиотека не очень красиво форматирует
                string json3 = JsonConvert.SerializeObject(products, Formatting.Indented);
                File.WriteAllText(@"Models\Products.json", json3);
            }
            return DeserializeJsonProducts();
        }
        /// <summary>
        /// получить товар
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static Product TryGetProduct(int id)
        {
            return DeserializeJsonProducts();
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

        public static Product DeserializeJsonProducts()
        {
            string currentFile = @"Models\Products.json";

            var strFromReq = new StreamReader(currentFile).ReadToEnd();
            var obj = JsonConvert.DeserializeObject(strFromReq).ToString();

            List<Product> productsJson = JsonConvert.DeserializeObject<List<Product>>(obj);

            if (IsValidJson(obj))
            {
                return null;//productsJson;
            }
            else
                return null;
        }
    }
}
