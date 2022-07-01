using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;

namespace OnlineShopWebApp.Areas.Admin.Models
{
    public class AddProductViewModel
    {
        [Required]
        public string NameEN { get; set; }
        
        public string NameRU { get; set; }

        [Required]
        public decimal Cost { get; set; }

        [Required]
        public string DescriptionEN { get; set; }

        public string DescriptionRU { get; set; }

        public bool Available { get; set; }

        public IFormFile[] UploadedFiles { get; set; }
    }
}
