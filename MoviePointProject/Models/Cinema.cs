using MoviePoint.logic.Models;

namespace MoviePoint.Models
{
    public class Cinema
    {
        public int Id { get; set; }

        public string Logo { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Location { get; set; }

        public virtual List<Movie>? Movies { get; set; }
		public virtual Tickets? Tickets { get; set; }

	}
}
