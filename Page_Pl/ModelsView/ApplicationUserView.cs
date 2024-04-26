using Microsoft.AspNetCore.Diagnostics;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Page_Pl.ModelsView
{
	public class ApplicationUserView
	{
		[Required(ErrorMessage ="First Name is Required")]
		public string FName { get; set; }


		[Required(ErrorMessage = "Last Name is Required")]
		public string LName { get; set; }


		[Required(ErrorMessage = "Email is Required")]
		[EmailAddress(ErrorMessage ="Enter Email")]
		public string Email { get; set; }

		[Required(ErrorMessage ="Enter Password")]
		[DataType(DataType.Password)]
		public string Password { get; set; }
		[Required(ErrorMessage = "Enter Confirm Password")]
		[DataType(DataType.Password)]
		[Compare("Password",ErrorMessage ="Password Does Not Match")]
		public string ConfirmPass {  get; set; }

		public bool IsAgree {  get; set; }
	}
}
