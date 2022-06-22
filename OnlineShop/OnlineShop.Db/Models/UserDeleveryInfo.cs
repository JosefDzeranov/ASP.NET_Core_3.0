using System;

namespace OnlineShop.Db.Models
{
    public class UserDeleveryInfo
    {
        public Guid Id { get; set; }
        public string Surname { get; set; }
        public string Firstname { get; set; }
        public string Secondname { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Commentary { get; set; }
    }
}
