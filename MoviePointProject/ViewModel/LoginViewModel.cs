using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MoviePoint.ViewModel
{
	public class LoginViewModel
	{
		public int Id { get; set; }
		public string Username { get; set; }

		[DataType(DataType.Password)]
		public string Password { get; set; }

		[DisplayName("Remember Me")]
		public bool rememberMe { get; set; }


	}
}
