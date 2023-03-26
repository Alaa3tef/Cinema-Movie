using System.ComponentModel.DataAnnotations.Schema;

namespace MoviePoint.Models
{
    public class Actor_Movie
    {
        public int ID { get; set; }

        [ForeignKey("Movie")]
        public int MovieID { get; set; }

        [ForeignKey("Actor")]
        public int ActorID { get; set; }

        public virtual Movie? Movie { get; set; }

        public virtual Actor? Actor { get; set; }

    }
}
