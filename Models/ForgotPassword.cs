using System.ComponentModel.DataAnnotations;

namespace WebApplication2.Models
{
	public class ForgotPassword
	{
		[Required(ErrorMessage = "Email is required")]
		[EmailAddress]
		public string Email { get; set; }
	}
}
