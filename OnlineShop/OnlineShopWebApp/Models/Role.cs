using System;
using System.ComponentModel.DataAnnotations;

namespace OnlineShopWebApp.Models
{
    public class Role
    {
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }
        public Rights Rights { get; set; }
        public Role()
        {
            Id = Guid.NewGuid();
            Rights = new Rights();
        }
    }
}
