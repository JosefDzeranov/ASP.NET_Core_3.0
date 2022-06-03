using System;
using System.ComponentModel.DataAnnotations;
using OnlineShopWebApp.Areas.Admin.Models.Attributes;

namespace OnlineShopWebApp.Areas.Admin.Models
{
    [EditNamePasswordEqual]
    public class ChangePasswordViewModel
    {
        public Guid Id { get; set; }

        [Required]
        [StringLength(25, MinimumLength = 2)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(25, MinimumLength = 2)]
        public string LastName { get; set; }

        [Required]
        public string CurrentPassword { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 4)]
        public string NewPassword { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 4)]
        [Compare("NewPassword")]
        public string ConfirmNewPassword { get; set; }
    }
}
