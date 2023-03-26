using Microsoft.AspNetCore.Identity;
using System.ComponentModel;

namespace MoviePoint.ViewModel
{
    public class RoleViewModel
    {
		[DisplayName("Role")]
		public string RoleID { get; set; }
        
		[DisplayName("User")]
        public string UserID { get; set; }

		public string? UserName { get; set; }

		public string? RoleName { get; set; }

		public List<IdentityUser>? Users { get; set; }

		public List<IdentityRole>? Roles { get; set; }
	}
}
