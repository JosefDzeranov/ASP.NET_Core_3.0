using System.Collections.Generic;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Interfase
{
    
    public interface IPersonMemoryStorage
    {
        List<Person> Persons { get; set; }
        void WriteToStorage();

        void ReadToStorage();

        void AddProductInCart(int productId, int personId);

        void DeleteProductInCart(int productId, int personId);

        Person FindPerson(int personId);
    }
}
