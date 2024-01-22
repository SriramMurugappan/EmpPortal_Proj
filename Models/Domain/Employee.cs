using System.ComponentModel.DataAnnotations;

namespace WebApplication2.Models.Domain
{
    public class Employee
    {
        public Guid Id { get; set; }
        
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [Required(ErrorMessage ="Email is required")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Salary is required")]
        public long Salary{ get; set; }

        public DateTime DateOfBirth { get; set; }
        [Required(ErrorMessage = "Department is required")]
        public string Department { get; set; }
    }
}
