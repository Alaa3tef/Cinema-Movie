using MoviePoint.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace MoviePoint.logic.ViewModel
{
	public class TicketsViewModel
	{
		public string MovieName { get; set; }
		public string CienmaName { get; set;}

		public DateTime date { get; set; }
		public int Quantity { get; set; }
		public int price { get; set; }
		public int TotalPrice { get; set; }
		public string? userName { get; set; }
		public List<Movie>? MovieList  { get; set; }
        public List<Cinema>? CinemaList { get; set; }


    }
}
