namespace MoviePoint.Models
{
    public class Actor
    {
        public int ID { get; set; }

        public string FullName { get; set; }

        public string ProfilePicUrl { get; set; }

        public string Bio { get; set;}

        public virtual List<Actor_Movie>? Actor_Movies { get; set; }
    }
}
