using System;
using System.Collections.Generic;
using System.Linq;
using OnlineShopWebApp.Interfase;
using OnlineShopWebApp.Models.Users;

namespace OnlineShopWebApp
{
    public class UserManager : IUserManager
    {
        
        private readonly IRoleManager _roleManager;
        private readonly IBuyerManager _buyerManager;

        private readonly List<User> users;
        private UserAutorized userAutorized { get; set; }
        private const string nameSave = "users";
        private IWorkWithData JsonStorage { get; } = new JsonWorkWithData(nameSave);
        private IWorkWithData AutorizedData { get; } = new JsonWorkWithData("autorization");
        public UserManager(IRoleManager roleManager, IBuyerManager buyerManager)
        {
            _roleManager = roleManager;
            _buyerManager = buyerManager;
            users = JsonStorage.Read<List<User>>();
            userAutorized = AutorizedData.Read<UserAutorized>();
        }
        public string GetLoginAuthorizedUser()
        {
            return userAutorized.Login;
        }
        public void Authorized(UserAutorized user)
        {
            userAutorized = user;
            AutorizedData.Write(userAutorized);
        }

        public bool CheckingForAuthorization()
        {
            if (userAutorized == null) return false;
            return true;
        }
        public bool GettingAccess(string userLogin, string action, string controller, string area)
        {
            bool permission = true;
            var user = FindByLogin(userLogin);
            var role = _roleManager.Find(user.RoleId);
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

        public void AssignRole(string userLogin, Guid roleId)
        {
            var user = FindByLogin(userLogin);
            user.SetRole(roleId);
            JsonStorage.Write(users);
            if (_roleManager.Find(roleId).Rights.BeBuyer) _buyerManager.AddBuyer(user);
        }

        public List<User> GetAll()
        {
            return users;
        }

        public User FindByLogin(string userLogin)
        {
            return users.FirstOrDefault(x => x.Login == userLogin);
        }

        public void Add(UserRegistration userInput)
        {
            User newUser = new User()
            {
                Login = userInput.Login,
                Password = userInput.Password
            };
            users.Add(newUser);
            JsonStorage.Write(users);
        }

        public void Remove(string login)
        {
            users?.RemoveAll(x => x.Login == login);
            _buyerManager.Remove(login);
            JsonStorage.Write(users);
        }

        public void ChangePassword(string login, string password)
        {
            var user = FindByLogin(login);
            user.Password = password;
            JsonStorage.Write(users);
        }

        public void ChangeInfo(UserInfo userInfo)
        {
            var user = FindByLogin(userInfo.Login);
            user.Firstname ??= userInfo.Firstname ;
            user.Secondname ??= userInfo.Secondname;
            user.Surname ??= userInfo.Surname;
            user.Surname ??= userInfo.Surname;
            if(userInfo.Age!=0) user.Age = userInfo.Age;
            user.Phone ??= userInfo.Phone;
            user.Email ??= userInfo.Email;
            JsonStorage.Write(users);
        }

        public void Exit()
        {
            userAutorized = null;
            AutorizedData.Write(userAutorized);
        }
    }
}
