using System.ComponentModel.DataAnnotations;

namespace Page_Pl.ModelsView
{
	public class LoginModelView
	{
		[Required(ErrorMessage = "Email is Required")]
		[EmailAddress(ErrorMessage = "Enter Email")]
		public string Email { get; set; }

		[Required(ErrorMessage = "Enter Password")]
		[DataType(DataType.Password)]
		public string Password { get; set; }

		public bool RememberMe {  get; set; }
	}
}
