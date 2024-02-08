using System;
using System.ComponentModel.DataAnnotations;

namespace WebApplication2.Models
{
    public class AddEmployeeViewModel
    {
        [Required(ErrorMessage = "Name is required")]
        [StringLength(100, ErrorMessage = "Name must be between {2} and {1} characters", MinimumLength = 2)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Salary is required")]
        [Range(0, long.MaxValue, ErrorMessage = "Salary must be a non-negative value")]
        public long Salary { get; set; }
        public DateTime DateOfBirth { get; set; }

        [Required(ErrorMessage = "Department is required")]
        public string Department { get; set; }
    }
}