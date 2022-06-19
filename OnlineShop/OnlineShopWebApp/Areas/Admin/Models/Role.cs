using System.ComponentModel.DataAnnotations;

namespace OnlineShopWebApp.Areas.Admin.Models
{
    public class Role
    {
        [Required(ErrorMessage = "Наименование роли не заполнено")]
        public string Name { get; set; }

        public Role() 
        { 
        
        }

        public Role(string name)
        {
            Name = name;
        }
    }
}