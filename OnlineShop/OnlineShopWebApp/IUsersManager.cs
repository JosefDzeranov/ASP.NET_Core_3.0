using OnlineShopWebApp.Models;
using System.Collections.Generic;

namespace OnlineShopWebApp
{
    public interface IUsersManager
    {
        public void RegisterUser(Registration regInfo);

        public void SaveNewUser(User user);
                   
        public  List<User> GetRegistredUsers();
        public bool Compare(Authorization authorization);
    }
}
