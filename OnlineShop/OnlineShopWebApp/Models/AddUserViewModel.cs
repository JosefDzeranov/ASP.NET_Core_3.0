using Microsoft.AspNetCore.Http;

namespace OnlineShopWebApp.Models
{
    public class AddUserViewModel
    {
        public string UserId { get; set; }
        public string Name { get; set; }
        public string Age { get; set; }
        public string Email { get; set; }
        public string ImagePath { get; set; }
        public IFormFile UploadedFile { get; set; }
    }
}
