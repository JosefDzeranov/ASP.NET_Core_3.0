//using System.Collections.Generic;
//using System.Linq;
//using OnlineShopWebApp.Areas.Admin.Models;

//namespace OnlineShopWebApp.Services
//{
//    public class InMemoryRolesRepository : IRolesRepository
//    {
//        private readonly List<Role> roles = new List<Role>();

//        public void Add(Role role)
//        {
//            roles.Add(role);
//        }

//        public List<Role> GetAll()
//        {
//            return roles;
//        }

//        public Role TryGetByName(string name)
//        {
//            return roles.FirstOrDefault(x => x.Name == name);

//        }

//        public void Remove(string name)
//        {
//            roles.RemoveAll(x => x.Name == name);
//        }

//    }
//}
