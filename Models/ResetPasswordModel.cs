using System.ComponentModel.DataAnnotations;

namespace WebApplication2.Models
{
	public class ResetPasswordModel
	{
		[Required]
		[EmailAddress]
		public string Email { get; set; }

		[Required]
		[DataType(DataType.Password)]
		public string Password { get; set; }

		[DataType(DataType.Password)]
		[Display(Name = "Confirm Password")]
		[Compare("Password",ErrorMessage = "Password and Confirmed Password must match")]
		public string ConfirmPassword { get; set;}

		public string Token { get; set; }
	}
}
