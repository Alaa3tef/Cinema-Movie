using Microsoft.AspNetCore.Cors.Infrastructure;
using MoviePoint.Models;

namespace MoviePoint.Repository
{
    public class ProducerRepository : IProducerRepository
    {
        MoviePointContext context;

        public ProducerRepository()
        {
            context = new MoviePointContext();
        }

        public List<Producer> GetAll()
        {
            return context.Producers.ToList();
        }

        public Producer GetById(int id)
        {
            return context.Producers.FirstOrDefault(c => c.Id == id);
        }
        public void Insert(Producer producer)
        {
            context.Producers.Add(producer);
            context.SaveChanges();
        }
        public void Update(int id, Producer producer)
        {
            Producer org = GetById(id);
            org.FullName = producer.FullName;
            org.ProfilePicture = producer.ProfilePicture;
            org.Bio = producer.Bio;
            context.SaveChanges();
        }
        public void Delete(int id)
        {
            Producer org = GetById(id);
            context.Producers.Remove(org);
            context.SaveChanges();
        }
    }
}
