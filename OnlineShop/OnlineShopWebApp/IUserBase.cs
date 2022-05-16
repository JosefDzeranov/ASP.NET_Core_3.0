using OnlineShopWebApp.Models;
using System.Collections.Generic;

namespace OnlineShopWebApp
{
    public interface IUserBase
    {
        void Add(User user);
        IEnumerable<User> AllUsers();
        bool Authentification(Authorization authorization);
        User TryGetById(int userId);
    }
}
