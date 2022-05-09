using OnlineShopWebApp.Models;
using System.Collections.Generic;

namespace OnlineShopWebApp
{
    public interface IUsersManager
    {
        void Add(UserAccount user);
        List<UserAccount> GetAll();
        UserAccount TryGetByName(string name);
        void ChangePassword (string userName, string newPassword);
        void Remove (string name);

        void Edit (UserAccount user);
        
    }
}