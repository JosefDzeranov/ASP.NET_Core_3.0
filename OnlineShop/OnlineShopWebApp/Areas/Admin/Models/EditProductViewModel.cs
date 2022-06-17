using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;

namespace OnlineShopWebApp.Areas.Admin.Models
{
    public class EditProductViewModel
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Range(1, 10000000, ErrorMessage = "Цена должна быть в пределах от 1 до 1млн.")]
        public decimal Cost { get; set; }
        [Required]
        public string Description { get; set; }
        public List<string> ImagesPaths { get; set; }
        public IFormFile[] UploadFiles { get; set; }

    }
}
