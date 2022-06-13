using OnlineShopWebApp.Models;
using System.Collections.Generic;

namespace OnlineShopWebApp
{
    public interface IUsersManager
    {
        void Add(UserViewModel user);
        List<UserViewModel> GetAll();
        UserViewModel TryGetByName(string name);
        void ChangePassword (string userName, string newPassword);
        void Remove (string name);

        void Edit (UserViewModel user);
        
    }
}