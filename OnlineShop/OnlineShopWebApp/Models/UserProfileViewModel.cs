//using Microsoft.AspNetCore.Http;
//using OnlineShop.db.Models;
//using System;
//using System.ComponentModel.DataAnnotations;

//namespace OnlineShopWebApp.ViewModels
//{
//    public class UserProfileViewModel
//    {
//        [Required(ErrorMessage = "не указано имя")]
//        [StringLength(16, MinimumLength = 2, ErrorMessage = "имя должно быть от 2 до 16 символов")]
//        public string FirstName { get; set; }
//        [Required(ErrorMessage = "не указана фамилия")]
//        [StringLength(25, MinimumLength = 2, ErrorMessage = "имя должно быть от 2 до 25 символов")]
//        public string LastName { get; set; }
//        [Required(ErrorMessage = "не указан email")]
//        [EmailAddress(ErrorMessage = "некорректный формат email")]
//        public string Email { get; set; }
//        public string Id { get; set; }
//        public string Phone { get; set; }
//        public string AvatarPath { get; set; }
//        public IFormFile UploadedImage { get; set; }

//    }
//}