using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace OnlineShopWebApp.Areas.Admin.Models
{
    public class AddProductViewModel
    {
        [Required]
        public string Name { get; set; }

        [Range(1, 10000000, ErrorMessage = "Цена должна быть в пределах от 1 до 1млн.")]
        public decimal Cost { get; set; }
        public IFormFile[] UploadFiles { get; set; }
        public string Description { get; set; }

    }
}
