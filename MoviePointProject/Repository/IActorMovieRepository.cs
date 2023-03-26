using MoviePoint.Models;

namespace MoviePoint.Repository
{
    public interface IActorMovieRepository
    {
        List<Actor_Movie> GetAll();
        Actor_Movie GetById(int id);
        void Insert(Actor_Movie actor_Movie);
        void Update(int id, Actor_Movie actor_Movie);
        void Delete(int id);
        List<int> ActorById(int id);
        List<Actor_Movie> GetByMovieId(int MovieID);

	}
}
