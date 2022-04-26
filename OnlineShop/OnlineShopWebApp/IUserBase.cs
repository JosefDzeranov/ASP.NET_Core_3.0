using OnlineShopWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShopWebApp
{
    public interface IUserBase
    {
        IEnumerable<User> AllUsers();

    }
}
