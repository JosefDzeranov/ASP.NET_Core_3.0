using OnlineShopWebApp.Models;
using System.Collections.Generic;
using System.Linq;

namespace OnlineShopWebApp.Controllers
{
    internal class InMemoryLoginsRepository : ILoginsRepository
    {
        private List<EnterData> logins = new List<EnterData>();

        public EnterData TryGetByUserId(string userId)
        {
            return logins.FirstOrDefault(x => x.UserId == userId);
        }

        public void Add(EnterData enterData)
        {
            var existingLogin = logins.FirstOrDefault(x => x.Login == enterData.Login);
            if (existingLogin == null)
            {
                logins.Add(enterData);
            }
        }
    }