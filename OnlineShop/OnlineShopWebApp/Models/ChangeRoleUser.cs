using System;
using System.Collections.Generic;

namespace OnlineShopWebApp.Models
{
    public class ChangeRoleUser
    {
        public Guid Id { get; set; }
        public string Login { get; set; }
        public string RoleName { get; set; }
        public List<Role> OtherRoles { get; set; }
    }
}
