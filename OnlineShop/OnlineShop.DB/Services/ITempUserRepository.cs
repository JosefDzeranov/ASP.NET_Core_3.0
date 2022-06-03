using OnlineShop.DB.Models;
using System;

namespace OnlineShop.DB.Services
{
    public interface ITempUserRepository
    {
        void Delete(Guid id);
        void Add(TempUser tempUser);
    }
}
