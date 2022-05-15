using OnlineShopWebApp.Models;
using System.Collections.Generic;

namespace OnlineShopWebApp
{
    public interface IUserBase
    {
        void Add(User user);
        IEnumerable<User> AllUsers();
        User TryGetById(int userId);
    }
}
