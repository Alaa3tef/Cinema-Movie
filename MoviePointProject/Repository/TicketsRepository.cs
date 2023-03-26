using Microsoft.EntityFrameworkCore;
using MoviePoint.logic.Models;
using MoviePoint.Models;

namespace MoviePoint.logic.Repository
{
	public class TicketsRepository: ITicketsRepository
	{
		MoviePointContext context;

		public TicketsRepository()
		{
			context = new MoviePointContext();
		}

		public List<Tickets> GetAll()
		{
			return context.Tickets.ToList();
		}

		public Tickets GetById(int id)
		{
			return context.Tickets.FirstOrDefault(c => c.Id == id);
		}
		public void Insert(Tickets tickets)
		{
			context.Tickets.Add(tickets);
			context.SaveChanges();
		}
		public void Update(int id, Tickets tickets)
		{
			Tickets org = GetById(id);
			org.date = tickets.date;
			org.price = tickets.price;
			org.Quantity = tickets.Quantity;
			org.CinemaID = tickets.CinemaID;
			org.MovieID = tickets.MovieID;
			org.userID = tickets.userID;
			context.SaveChanges();
		}
		public void Delete(int id)
		{
			Tickets org = GetById(id);
			context.Tickets.Remove(org);
			context.SaveChanges();
		}
	}
}
