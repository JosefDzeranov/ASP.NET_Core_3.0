using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OnlineShopWebApp.Areas.Admin.Models
{
    public class EditProductViewModel
    {
        public Guid Id { get; set; }

        [Required]
        public string NameEN { get; set; }

        [Required]
        public string NameRU { get; set; }

        [Required]
        public decimal Cost { get; set; }

        [Required]
        public string DescriptionEN { get; set; }
        
        [Required]
        public string DescriptionRU { get; set; }

        public bool Available { get; set; }

        public List<string> ImagePaths { get; set; }

        public IFormFile[] UploadedFiles { get; set; }
    }
}
