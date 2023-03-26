using MoviePoint.Models;

namespace MoviePoint.Repository
{
    public class CinemaRepository : ICinemaRepository
    {
        MoviePointContext context;

        public CinemaRepository()
        {
            context = new MoviePointContext();
        }

        public List<Cinema> GetAll()
        {
            return context.Cinemas.ToList();
        }

        public Cinema GetById(int id)
        {
            return context.Cinemas.FirstOrDefault(c => c.Id == id);
        }
        public Cinema GetByName(string Name)
        {
            return context.Cinemas.FirstOrDefault(c => c.Name == Name);
        }
        public void Insert(Cinema cinema)
        {
            context.Cinemas.Add(cinema);
            context.SaveChanges();
        }
        public void Update(int id, Cinema cinema)
        {
            Cinema org = GetById(id);
            org.Name = cinema.Name;
            org.Location = cinema.Location;
            org.Logo = cinema.Logo;
            org.Description = cinema.Description;
            context.SaveChanges();
        }
        public void Delete(int id)
        {
            Cinema org = GetById(id);
            context.Cinemas.Remove(org);
            context.SaveChanges();
        }
    }
}
