using Microsoft.AspNetCore.Identity;
using MoviePoint.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace MoviePoint.logic.Models
{
	public class Tickets
	{
		
			public int Id { get; set; }
			public DateTime date { get; set; }

			[ForeignKey("Movie")]
			public int MovieID { get; set; }

			[ForeignKey("Cinema")]
			public int CinemaID { get; set; }
			public int Quantity { get; set; }
			public int price { get; set; }

			[ForeignKey("user")]
			public string userID { get; set; }

			public virtual IdentityUser user { get; set; }
			public virtual Cinema Cinema { get; set; }
			public virtual Movie Movie { get; set; }
		

	}
}
