using MoviePoint.Models;

namespace MoviePoint.Repository
{
    public interface ICinemaRepository
    {
        List<Cinema> GetAll();
        Cinema GetById(int id);
        void Insert(Cinema cinema);
        void Update(int id, Cinema cinema);
        void Delete(int id);
        Cinema GetByName(string Name);
    }
}
