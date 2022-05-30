using System;

namespace OnlineShop.DB
{
    public static class Const
    {
        public static Guid UserId;
        public const string AdminRoleName = "Admin";
        public const string UserRoleName = "User";
        static Const()
        {
            UserId = Guid.NewGuid();
        }
    }

   
}
