using System.ComponentModel.DataAnnotations;

namespace MoviePoint.ViewModel
{
    public class RegistrationViewModel
    {
        [Required]
        public string UserName { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

		[Display(Name = "Phone Number")]
		[DataType(DataType.PhoneNumber)]
		[RegularExpression(@"^[0][1-9]\d{9}$|^[1-9]\d{9}$", ErrorMessage = "Not a valid phone number")]
		public string Phone { get; set; }


        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
    }
}
