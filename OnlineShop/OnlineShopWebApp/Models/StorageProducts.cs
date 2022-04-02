﻿using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;

namespace OnlineShopWebApp.Models
{
    public class StorageProducts
    {
        //нужно как минимум три метода: сформировать json если его нет, получить список, получить товар, 
        private static readonly List<Product> products = new List<Product>()
        {
            new Product(1, "Составление документов, исков в суд", 5000, "Составление и оформление документов для подачи в суд"),
            new Product(2, "Составление документов для регистрации/банкротства ЮЛ", 4000, "Составление документов для регистрации/банкротства ЮЛ"),
            new Product(3, "Сопровождение и ведение гражданского дела в суде", 6000, "Сопровождение и ведение гражданского дела в суде"),
            new Product(4, "Консультация по вопросам", 3000, "Консультация по вопросам"),
            new Product(5, "Анализ документов и договоров", 3000, "Правовая экспертиза документов и договоров"),
        };
        
        //string json = Newtonsoft.Json.JsonConvert.SerializeObject(products);
        //string json2 = JsonSerializer.Serialize(products);
        //string json3 = JsonConvert.SerializeObject(products, Formatting.Indented);
        //File.WriteAllText(@"D:\myJson.json", json);


        //получить описание товара
        public static string ShowProducts()
        {
            string output = string.Empty;
            foreach (var product in products)
            {
                output += $"{product.Id}\n{product.Cost}\n{product.Description}\n\n";
            }
            return output;
        }

        //получить товар
        public static Product TryGetProduct (int id)
        {
            return products.FirstOrDefault(x => x.Id == id);
        }

        //получить список товаров
        public List<Product> TryGetListProduct(int id)
        {
            return products;
        }
    }
}
