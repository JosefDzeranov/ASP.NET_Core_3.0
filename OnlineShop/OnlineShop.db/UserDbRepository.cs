using System.Linq;
using User = OnlineShop.db.Models.User;

namespace OnlineShop.db
{
    public class UserDbRepository
    {
        private readonly DatabaseContext identityContext;

        public UserDbRepository(DatabaseContext identityContext)
        {
            this.identityContext= identityContext;
        }

        public User TryGetByTelegramUserId(long? telegramUserId)
        {
            return identityContext.Users.FirstOrDefault(x => x.TelegramUserId == telegramUserId);
        }

        public User TryGetByName(string name)
        {
            return identityContext.Users.FirstOrDefault(x => x.UserName == name);
        }

        public bool UpdateTelegramUserId(string phone, long userId)
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

        public void UpdateUser()
        {
            identityContext.SaveChanges();
        }
    }
}
