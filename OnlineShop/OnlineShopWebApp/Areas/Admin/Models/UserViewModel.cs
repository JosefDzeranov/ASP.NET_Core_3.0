using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OnlineShopWebApp.Areas.Admin.Models
{
    public class UserViewModel
    {
        public Guid Id { get; set; }

        [Required]
        [StringLength(25, MinimumLength = 2)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(25, MinimumLength = 2)]
        public string LastName { get; set; }

        public IList<string> UserRoles { get; set; }

        [Required]
        [Phone]
        public string Phone { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }
        public string Password { get; set; }

        public UserViewModel()
        {
            UserRoles = new List<string>();
        }
    }
}
