using System;
using OnlineShopWebApp.Models;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace OnlineShopWebApp
{
    public class UserStorage : IUserStorage
    {
        private List<User> _users = new List<User>();
        
        public void CreateUser(SignUp signup)
        {

        }

        public void AuthorizeUser(SignIn signin)
        {

        }
    }
}
