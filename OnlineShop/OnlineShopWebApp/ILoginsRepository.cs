using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Controllers
{
    internal interface ILoginsRepository
    {
       EnterData TryGetByUserId(string userId);
       void Add(EnterData enterData)
    }
}