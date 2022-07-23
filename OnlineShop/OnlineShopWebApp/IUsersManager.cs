using OnlineShopWebApp.Models;
using System;
using System.Collections.Generic;

namespace OnlineShopWebApp
{
    public interface IUsersManager
    {
        public void RegisterUser(Registration regInfo);

        public void SaveNewUser(UserViewModel user);

        public List<UserViewModel> GetRegistredUsers();
        public bool Compare(Authorization authorization);

        public UserViewModel GetUserById(Guid id);

        public void EditUser(UserViewModel editedUser);
        void DeleteUser(UserViewModel deletedUser);
    }
}
