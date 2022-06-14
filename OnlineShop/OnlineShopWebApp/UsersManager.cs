using System;
using System.Collections.Generic;
using System.Linq;
using OnlineShopWebApp.Interfase;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp
{
    public class UsersManager : IUsersManager
    {

        private readonly List<User> users;
        private UserAutorized userAutorized { get; set; }
        private const string nameSave = "users";
        private IWorkWithData JsonStorage { get; } = new JsonWorkWithData(nameSave);
        private IWorkWithData AutorizedData { get; } = new JsonWorkWithData("autorization");
        public UsersManager()
        {
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

        public void AssignRole(string userLogin, Guid roleId)
        {
            var user = Find(userLogin);
            user.SetRole(roleId);
            Save();
        }

        public List<User> GetAll()
        {
            return users;
        }

        public User Find(string userLogin)
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
            Save();
        }

        public void Remove(string login)
        {
            users?.RemoveAll(x => x.Login == login);
            Save();
        }

        public void ChangePassword(string login, string password)
        {
            var user = Find(login);
            user.Password = password;
            Save();
        }

        public void ChangeInfo(UserInfo userInfo)
        {
            var user = Find(userInfo.Login);
            user.Firstname ??= userInfo.Firstname ;
            user.Secondname ??= userInfo.Secondname;
            user.Surname ??= userInfo.Surname;
            user.Surname ??= userInfo.Surname;
            if(userInfo.Age!=0) user.Age = userInfo.Age;
            user.Phone ??= userInfo.Phone;
            user.Email ??= userInfo.Email;
            Save();
        }

        public void Exit()
        {
            userAutorized = null;
            AutorizedData.Write(userAutorized);
        }

        private void Save()
        {
            JsonStorage.Write(users);
        }
    }
}
