using System.ComponentModel.DataAnnotations;

namespace OnlineShopWebApp.Areas.Admin.Models
{
    public class Role
    {
        [Required]
        public string Name { get; set; }

        public Role() // Empty ctor for XML serializing.
        { }
        public Role(string name)
        {
            Name = name;
        }
    }
}
