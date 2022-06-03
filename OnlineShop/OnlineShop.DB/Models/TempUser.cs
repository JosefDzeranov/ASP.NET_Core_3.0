using System;

namespace OnlineShop.DB.Models
{
    public class TempUser
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
     
    }
}
