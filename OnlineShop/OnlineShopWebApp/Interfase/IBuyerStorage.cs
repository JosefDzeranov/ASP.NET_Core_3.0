using System.Collections.Generic;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Interfase
{
    public interface IBuyerStorage
    {
        List<Buyer> Persons { get; set; }
        void WriteToStorage();

        void ReadToStorage();

        void AddProductInCart(int productId, int personId, IProductStorage productCatalog);

        void DeleteProductInCart(int productId, int personId);

        Buyer FindPerson(int personId);
    }
}
