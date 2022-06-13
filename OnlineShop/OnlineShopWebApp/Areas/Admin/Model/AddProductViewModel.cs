using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;

namespace OnlineShopWebApp.Admin.Models
{
    public class AddProductViewModel
    {
        [Required]
        public string Name { get; set; }
        [Range(500, 10000, ErrorMessage = "Cost should be between 500 and 10000 Rub")]
        [DataType(DataType.Currency, ErrorMessage = "Number")]
        public decimal Cost { get; set; }
        [Required]
        public string Description { get; set; }
        public IFormFile[] UploadedFiles { get; set; }

    }
}
