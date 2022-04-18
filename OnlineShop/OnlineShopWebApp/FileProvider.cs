
using Newtonsoft.Json;
using OnlineShopWebApp.Models;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace OnlineShopWebApp
{
    public static class FileProvider
    {
        public static void Append(string fileName, string orderData)
        {
            var writer = new StreamWriter(fileName, true, Encoding.UTF8);
            writer.WriteLine(orderData);
            writer.Close();
        }
        
        public static string Get(string fileName)
        {
            var reader = new StreamReader(fileName, Encoding.UTF8);
            var value = reader.ReadToEnd();
            reader.Close();
            return value;
        }

       
    }
}