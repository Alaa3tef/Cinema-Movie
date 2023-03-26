using MoviePoint.Models;

namespace MoviePoint.Repository
{
    public class ActorRepository : IActorRepository
    {
        MoviePointContext context;

        public ActorRepository()
        {
            context = new MoviePointContext();
        }

        public List<Actor> GetAll()
        {
            return context.Actors.ToList();
        }

        public Actor GetById(int id)
        {
            return context.Actors.FirstOrDefault(c => c.ID == id);
        }
        public void Insert(Actor actor)
        {
            context.Actors.Add(actor);
            context.SaveChanges();
        }
        public void Update(int id, Actor actor)
        {
            Actor org = GetById(id);
            org.FullName = actor.FullName;
            org.ProfilePicUrl = actor.ProfilePicUrl;
            org.Bio = actor.Bio;
            context.SaveChanges();
        }
        public void Delete(int id)
        {
            Actor org = GetById(id);
            context.Actors.Remove(org);
            context.SaveChanges();
        }
    }
}
