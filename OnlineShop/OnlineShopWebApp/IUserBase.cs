using OnlineShopWebApp.Areas.Admin.Models;
using OnlineShopWebApp.Models;
using System.Collections.Generic;

namespace OnlineShopWebApp
{
    public interface IUserBase
    {
        void Add(User user);
        List<User> AllUsers();
        bool Authentification(Authorization authorization);
        void Delete(int userId);
        void Edit(User user);
        void NewPassword(NewPassword newPassword);
        User TryGetById(int userId);
    }
}
