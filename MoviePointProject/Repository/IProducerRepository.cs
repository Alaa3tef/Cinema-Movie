using Microsoft.AspNetCore.Cors.Infrastructure;
using MoviePoint.Models;

namespace MoviePoint.Repository
{
    public interface IProducerRepository
    {
        List<Producer> GetAll();
        Producer GetById(int id);
        void Insert(Producer producer);
        void Update(int id, Producer producer);
        void Delete(int id);
    }
}
