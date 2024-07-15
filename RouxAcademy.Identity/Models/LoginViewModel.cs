using System.ComponentModel.DataAnnotations;

namespace RouxAcademy.Models
{
	public class LoginViewModel
	{
		[Required]
		[EmailAddress]
		[Display(Name = "Email")]
		public required string Email { get; set; }

		[Required]
		[DataType(DataType.Password)]
		[StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
		[Display(Name = "Password")]
		public required string Password { get; set; }

		[Display(Name = "Remember me?")]
		public bool RememberMe { get; set; }
	}
}
