using MoviePoint.Models;
using MoviePoint.ViewModel.Enum;
using System.ComponentModel.DataAnnotations.Schema;

namespace MoviePoint.ViewModel
{
    public class MoiveViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int Price { get; set; }

        public string ImageUrl { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndtDate { get; set; }

        public MovieCategory Category { get; set; }
        public string videoURL { get; set; }

        [ForeignKey("Cinema")]
        public int CinemaID { get; set; }

        [ForeignKey("Producer")]
        public int ProducerID { get; set; }
        public List<Actor>? AllActors { get; set; }
        public List<Actor>? ActorsObj { get; set; }
        public List<int>? Actors { get; set; }
        public List<Cinema>? cinemas { get; set; }
        public List<Producer>? producers { get; set; }
        public virtual List<Actor_Movie>? Actor_Movies { get; set; }


    }
}
