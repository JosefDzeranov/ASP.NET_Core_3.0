using OnlineShopWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace OnlineShopWebApp
{
    public class UsersInMemoryRepository : IUserBase
    {
        public IEnumerable<User> AllUsers()
        {
            var xDoc = XDocument.Load("Models/users.xml");
            var users = xDoc.Element("users")
                               .Elements("user")
                               .Select(p => new User(
                                       p.Element("id").Value,
                                       p.Element("name").Value,
                                       p.Element("phone").Value));
            return users;
        }
    }
}






