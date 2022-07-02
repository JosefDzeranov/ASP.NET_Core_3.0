using System.Linq;
using Telegram.Bot.Types;
using User = OnlineShop.db.Models.User;

namespace OnlineShop.db
{
    public class UserDbRepository
    {
        private readonly IdentityContext identityContext;

        public UserDbRepository(IdentityContext identityContext)
        {
            this.identityContext= identityContext;
        }

        public User TryGetByTelegramUserId(string telegramUserId)
        {
            return identityContext.Users.FirstOrDefault(x => x.TelegramUserId == telegramUserId);
        }

        public User TryGetByName(string name)
        {
            return identityContext.Users.FirstOrDefault(x => x.UserName == name);
        }

        public bool UpdateTelegramUserId(string phone, string userId)
        {
            var user = identityContext.Users.FirstOrDefault(x => x.PhoneNumber == phone);
            if (user != null)
            {
                user.TelegramUserId = userId;
                identityContext.SaveChanges();
                return true;
            }

            return false;
        }
    }
}
