using OnlineShop.DB.Models;
using System;


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

        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
