using Microsoft.AspNetCore.Identity;
using MoviePoint.Models;

namespace MoviePoint.ViewModel
{
	public class MovieWithUserViewModel
	{
		public Movie Movie { get; set; }
		//public IdentityUser IdentityUser { get; set; }
		//public String UserName { get; set; }	
		public String UserID { get; set; }

		public List<Comment>? Comments { get; set; }
	}
}
