using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

//временный класс, для обучения тестированию
namespace OnlineShopWebApp.Models
{
    [Table("Employee")]
    public class Employee
    {
        public Guid Id { get; set; }
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Age is required")]
        public int Age { get; set; }

        [Required(ErrorMessage = "Account number is required")]
        public string AccountNumber { get; set; }

    }
}
