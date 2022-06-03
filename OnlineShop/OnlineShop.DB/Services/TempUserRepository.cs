using OnlineShop.DB.Models;
using System;
using System.Linq;

namespace OnlineShop.DB.Services
{
    public class TempUserRepository : ITempUserRepository
    {
        private readonly OnlineShopContext onlineShopContext;

        public TempUserRepository(OnlineShopContext onlineShopContext)
        {
            this.onlineShopContext = onlineShopContext;
        }

        public void Add(TempUser tempUser)
        {
            onlineShopContext.TempUsers.Add(tempUser);
            onlineShopContext.SaveChanges();
        }

        public void Delete(string id)
        {
            var tempUser = onlineShopContext.TempUsers.FirstOrDefault(x => x.Id == new Guid(id));
            onlineShopContext.TempUsers.Remove(tempUser);
            onlineShopContext.SaveChanges();
        }
    }
}
