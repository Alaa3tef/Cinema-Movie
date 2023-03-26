using MoviePoint.Models;

namespace MoviePoint.Repository
{
    public interface IActorRepository
    {
        List<Actor> GetAll();
        Actor GetById(int id);
        void Insert(Actor actor);
        void Update(int id, Actor actor);
        void Delete(int id);
    }
}
