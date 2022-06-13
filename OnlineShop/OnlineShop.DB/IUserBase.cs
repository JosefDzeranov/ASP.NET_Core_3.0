using System.Collections.Generic;
using OnlineShop.DB.Models;

namespace OnlineShop.DB
{
    public interface IUserBase
    {
        void Add(User user);
        IEnumerable<User> AllUsers();
        //bool Authentification(Authorization authorization);
        void Delete(string userId);
        void Edit(User user);
        //void NewPassword(NewPassword newPassword);
        User TryGetById(string userId);
    }
}
