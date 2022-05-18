using System;
using System.Collections.Generic;
using System.Linq;
using OnlineShopWebApp.Interfase;
using OnlineShopWebApp.Models;
using OnlineShopWebApp.Models.Users;

namespace OnlineShopWebApp
{
    public class UserManager : IUserManager
    {
        private readonly IRoleManager roleManager;

        private readonly List<User> users;
        private const string nameSave = "users";
        private IWorkWithData JsonStorage { get; } = new JsonWorkWithData(nameSave);

        public UserManager(IRoleManager roleManager)
        {
            this.roleManager = roleManager;
            users = JsonStorage.Read<List<User>>();
        }

        public bool GettingAccess(string userLogin, string action, string controller, string area)
        {
            bool permission = true;
            var user = FindByLogin(userLogin);
            var role = roleManager.Find(user.RoleUser.Id);
            if (role.Rights.BeAdmin == false)
            {
                foreach (var v in role.Rights.tabooAdmin)
                {
                    if (area == v.Area)
                    {
                        permission = false;
                        return permission; 
                    }
                    if (area == v.Area && controller == v.Controller)
                    {
                        permission = false;
                        return permission;
                    }
                    if (area == v.Area && controller == v.Controller && action == v.Action)
                    {
                        permission = false;
                        return permission;
                    }
                }
                foreach (var v in role.Rights.tabooBuyer)
                {
                    if (area == v.Area)
                    {
                        permission = false;
                        return permission;
                    }
                    if (area == v.Area && controller == v.Controller)
                    {
                        permission = false;
                        return permission;
                    }
                    if (area == v.Area && controller == v.Controller && action == v.Action)
                    {
                        permission = false;
                        return permission;
                    }
                }
            }
            return permission;
        }

        public List<User> GetAll()
        {
            return users;
        }

        public User FindByLogin(string userLogin)
        {
            return users.FirstOrDefault(x => x.Login == userLogin);
        }

        public void Add(User user)
        {
            users.Add(user);
            JsonStorage.Write(users);
        }

        public void Remove(string userLogin)
        {
            users.RemoveAll(x => x.Login == userLogin);
            JsonStorage.Write(users);
        }
    }
}
