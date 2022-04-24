using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShopWebApp.Models
{
    public class Image
    {

        public string Id { get; set; }

        public string Path { get; set; } = "";

        public string Title { get; set; } = "item";

        public string Name { get; set; } = "item";

        public IFormFile ImageFile { get; set; }

    }
}
