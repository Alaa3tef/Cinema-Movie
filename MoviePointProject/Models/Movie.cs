using MoviePoint.logic.Models;
using MoviePoint.ViewModel.Enum;
using System.ComponentModel.DataAnnotations.Schema;

namespace MoviePoint.Models
{
    public class Movie
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int Price { get; set; }

        public string ImageUrl { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndtDate { get; set; }
        public string videoURL { get; set; }

        public MovieCategory Category { get; set; }

        public virtual List<Actor_Movie> Actor_Movies { get; set; }

        public virtual Cinema Cinema { get; set; }

        [ForeignKey("Cinema")]
        public int CinemaID { get; set; }

        public virtual Producer Producer { get; set; }

        [ForeignKey("Producer")]
        public int ProducerID { get; set; }
       public virtual List<Comment> comments { get; set; }
		public virtual Tickets Tickets { get; set; }
	}
}
