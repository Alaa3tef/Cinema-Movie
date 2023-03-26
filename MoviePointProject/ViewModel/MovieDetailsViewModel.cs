using MoviePoint.Models;
using MoviePoint.ViewModel.Enum;
using System.ComponentModel.DataAnnotations.Schema;

namespace MoviePoint.ViewModel
{
	public class MovieDetailsViewModel
	{
		public string MovieName { get; set; }

		public string MovieDescription { get; set; }

		public int MoviePrice { get; set; }

		public string MovieImageUrl { get; set; }

		public DateTime MovieStartDate { get; set; }

		public DateTime MovieEndDate { get; set; }

		public MovieCategory MovieCategory { get; set; }

		public string CinemaName { get; set; }
		public string CinemaLocation { get; set; }

		public string ProducerName { get; set; }
		
	}
}
