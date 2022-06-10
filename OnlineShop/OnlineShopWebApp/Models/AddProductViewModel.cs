using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OnlineShopWebApp.Models
{
    public class AddProductViewModel
    {
        [Required(ErrorMessage = "Название не заполнено")]
        [StringLength(25, MinimumLength = 2, ErrorMessage = "название должно быть от 2 до 25 символов")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Цена должна быть указана")]
        [Range(typeof(decimal), "25.00", "50000.00")]
        public decimal Cost { get; set; }
        public string Description { get; set; }
        public List<IFormFile> UploadedImages { get; set; }
    }
}
