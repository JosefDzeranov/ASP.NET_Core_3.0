using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using OnlineShopWebApp.Interface;

namespace OnlineShopWebApp.Models
{
    public class ProductsStorage : IProductsStorage
    {
        private readonly List<Product> products = new List<Product>()
        {
            new Product(0,"Составление документов, исков в суд", 5000, "Составление и оформление документов для подачи в суд", "/images/court.jpg"),
            new Product(1,"Составление документов для регистрации/банкротства ЮЛ", 4000, "Составление документов для регистрации/банкротства ЮЛ","/images/bankruptcy.jpg"),
            new Product(2,"Сопровождение и ведение гражданского дела в суде", 6000, "Сопровождение и ведение гражданского дела в суде","/images/civil_case.jpg"),
            new Product(3,"Консультация по вопросам", 3000, "Консультация по вопросам","/images/law_consultation.jpg"),
            new Product(4,"Анализ документов и договоров", 3000, "Правовая экспертиза документов и договоров","/images/examination_documents.jpg"),
        };

        public List<Product> GetAllFirst()
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

        public List<Product> GetAll()
        {
            string currentFile = @"Models\Products.json";

            if (!File.Exists(currentFile))
            {
                return null;
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

        public Product TryGetProduct(int id)
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

        public List<Product> DeserializeJsonProducts()
        {
            string currentFile = @"Models\Products.json";

            var strFromReq = new StreamReader(currentFile).ReadToEnd();

            List<Product> productsJson = JsonConvert.DeserializeObject<List<Product>>(strFromReq);

            return productsJson;
        }

        public void Delete(int productId)
        {
            List<Product> productsJson;

            try
            {
                productsJson = DeserializeJsonProducts();

                var product = productsJson.FirstOrDefault(x => x.Id == productId);

                productsJson.Remove(product);


                string currentFile = @"Models\Products.json";
                
                if (File.Exists(currentFile))
                {
                    GC.Collect();
                    GC.WaitForPendingFinalizers();
                    File.Delete(currentFile);
                }

                if (productsJson.Count != 0)
                {
                    string obj = JsonConvert.SerializeObject(productsJson, Formatting.Indented);
                    File.WriteAllText(@"Models\Products.json", obj);
                }
            }
            catch (Exception)
            {

            }
        }

        public void SaveEditedProduct(Product newProduct)
        {
            List<Product> productsJson;

            try
            {
                productsJson = DeserializeJsonProducts();

                var product = productsJson.FirstOrDefault(x => x.Id == newProduct.Id);
                product.Name = newProduct.Name;
                product.Cost = newProduct.Cost;
                product.Description = newProduct.Description;

                string currentFile = @"Models\Products.json";

                if (File.Exists(currentFile))
                {
                    GC.Collect();
                    GC.WaitForPendingFinalizers();
                    File.Delete(currentFile);
                }

                if (productsJson.Count != 0)
                {
                    string obj = JsonConvert.SerializeObject(productsJson, Formatting.Indented);
                    File.WriteAllText(@"Models\Products.json", obj);
                }
            }
            catch (Exception)
            {

            }
        }

        public void Add(Product product)
        {
            List<Product> productsJson;

            productsJson = DeserializeJsonProducts();
            string currentFile = @"Models\Products.json";

            if (!File.Exists(currentFile))
            {
                GC.Collect();
                GC.WaitForPendingFinalizers();
                File.Delete(currentFile);
            }

            try
            {
                productsJson = DeserializeJsonProducts();

                List<Product> newProductsJson = new List<Product>();
                newProductsJson.Add(product);

                if (productsJson.Count != 0)
                {
                    string obj = JsonConvert.SerializeObject(productsJson, Formatting.Indented);
                    File.WriteAllText(@"Models\Products.json", obj);
                }
            }
            catch (Exception)
            {

            }
        }
    }
}
