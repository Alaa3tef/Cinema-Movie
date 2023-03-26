using MoviePoint.Models;
using System.Collections.Generic;

namespace MoviePoint.Repository
{
    public class ActorMovieRepository : IActorMovieRepository
    {
        MoviePointContext context;

        public ActorMovieRepository()
        {
            context = new MoviePointContext();
        }

        public List<Actor_Movie> GetAll()
        {
            return context.Actor_Movies.ToList();
        }

        public Actor_Movie GetById(int id)
        {
            return context.Actor_Movies.FirstOrDefault(c => c.ID == id);
        }

		public List <Actor_Movie> GetByMovieId(int MovieID)
		{

			return context.Actor_Movies.Where(c => c.MovieID == MovieID).ToList();
		}

		public void Insert(Actor_Movie actor_Movie)
        {
            context.Actor_Movies.Add(actor_Movie);
            context.SaveChanges();
        }
        public void Update(int id, Actor_Movie actor_Movie)
        {
            Actor_Movie org = GetById(id);
            org.ActorID = actor_Movie.ActorID;
            org.MovieID = actor_Movie.MovieID;
            context.SaveChanges();
        }
        public void Delete(int id)
        {
            Actor_Movie org = GetById(id);
            context.Actor_Movies.Remove(org);
            context.SaveChanges();
        }


		public List<int> ActorById(int id)
		{
			return context.Actor_Movies.Where(m => m.MovieID == id).Select(a => a.ActorID).ToList();
            

		}
	}
}
