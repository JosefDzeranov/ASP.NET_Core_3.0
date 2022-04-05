﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace OnlineShopWebApp.Models
{
    public class ProductsStorage
    {

        private static readonly List<Product> products = new List<Product>()
        {
            new Product(1,"Составление документов, исков в суд", 5000, "Составление и оформление документов для подачи в суд"),
            new Product(2,"Составление документов для регистрации/банкротства ЮЛ", 4000, "Составление документов для регистрации/банкротства ЮЛ"),
            new Product(3,"Сопровождение и ведение гражданского дела в суде", 6000, "Сопровождение и ведение гражданского дела в суде"),
            new Product(4,"Консультация по вопросам", 3000, "Консультация по вопросам"),
            new Product(5,"Анализ документов и договоров", 3000, "Правовая экспертиза документов и договоров"),
        };

        public static List<Product> GetAll()
        {
            string currentFile = @"Models\Products.json";

            if (!File.Exists(currentFile))
            {
                string obj = JsonConvert.SerializeObject(products, Formatting.Indented);
                File.WriteAllText(@"Models\Products.json", obj);
            }
            List<Product> productsJson;

            try
            {
                productsJson = DeserializeJsonProducts();
            }
            catch (Exception)
            {
                return null;
            }

            return productsJson;
        }

        public static Product TryGetProduct (int id)
        {
            List<Product> productsJson;

            try
            {
                productsJson = DeserializeJsonProducts();
            }
            catch (Exception) 
            { 
                return null; 
            }

            return productsJson.FirstOrDefault(x => x.Id == id);
        }

        public static List<Product> DeserializeJsonProducts()
        {
            string currentFile = @"Models\Products.json";

            var strFromReq = new StreamReader(currentFile).ReadToEnd();

            List<Product> productsJson = JsonConvert.DeserializeObject<List<Product>>(strFromReq);

            return productsJson;
        }

    }
}
