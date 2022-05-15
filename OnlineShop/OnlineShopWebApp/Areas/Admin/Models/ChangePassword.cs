using System;
using System.ComponentModel.DataAnnotations;
using OnlineShopWebApp.Areas.Admin.Models.Attributes;

namespace OnlineShopWebApp.Areas.Admin.Models
{
    [EditNamePasswordEqual]
    public class ChangePassword
    {
        public Guid Id { get; set; }

        [Required]
        [StringLength(25, MinimumLength = 2)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(25, MinimumLength = 2)]
        public string LastName { get; set; }

       // public string OldPassword { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 4)]
        public string Password { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 4)]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
    }
}
