using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShopWebApp.Models
{
    public class User
    {
        [Required(ErrorMessage ="Please enter Login.")]
        [StringLength(10, MinimumLength =2, ErrorMessage ="Login should has length between 2 and 10 characters.")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Please enter E-mail.")]
        [EmailAddress(ErrorMessage = "Please enter vald E-mail.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please enter Password.")]
        [StringLength(15, MinimumLength = 5, ErrorMessage = "Password should has length between 5 and 15 characters.")]
        public string Password { get; set; }
        
        public bool IsRemembered { get; set; } 

    }
}
