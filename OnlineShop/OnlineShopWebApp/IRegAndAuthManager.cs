using OnlineShopWebApp.Models;
using System.Collections.Generic;

namespace OnlineShopWebApp
{
    public interface IRegAndAuthManager
    {
        public void Register(Registration regInfo);
        public  List<Registration> GetRegistredUsers();
        public bool Compare(Authorization authorization);
    }
}
