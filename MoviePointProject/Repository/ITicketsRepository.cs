using MoviePoint.logic.Models;
using MoviePoint.Models;

namespace MoviePoint.logic.Repository
{
	public interface ITicketsRepository
	{
		List<Tickets> GetAll();
		Tickets GetById(int id);
		void Insert(Tickets tickets);
		void Update(int id, Tickets tickets);
		void Delete(int id);
	}
}
