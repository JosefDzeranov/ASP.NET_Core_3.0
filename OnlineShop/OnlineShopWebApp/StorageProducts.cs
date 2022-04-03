using System.Collections.Generic;
using System.Linq;

namespace OnlineShopWebApp.Models
{
    public class StorageProducts
    {
        //нужно как минимум три метода: сформировать json если его нет, получить список, получить товар, 
        private static List<Product> products = new List<Product>()
        {
            new Product("Составление документов, исков в суд", 5000, "Составление и оформление документов для подачи в суд"),
            new Product("Составление документов для регистрации/банкротства ЮЛ", 4000, "Составление документов для регистрации/банкротства ЮЛ"),
            new Product("Сопровождение и ведение гражданского дела в суде", 6000, "Сопровождение и ведение гражданского дела в суде"),
            new Product("Консультация по вопросам", 3000, "Консультация по вопросам"),
            new Product("Анализ документов и договоров", 3000, "Правовая экспертиза документов и договоров"),
        };

        public List<Product> GetAll() 
        { 
            return products; 
        }

        //получить описание товара
        public static string ShowProducts()
        {
            string output = string.Empty;
            foreach (var product in products)
            {
                output += $"{product.Id}\r\n{product.Name}\r\n{product.Cost}\r\n{product.Description}\n\n";
            }
            return output;
        }

        //получить товар
        public static Product TryGetProduct (int id)
        {
            return products.FirstOrDefault(product => product.Id == id);
        }
    }
}
