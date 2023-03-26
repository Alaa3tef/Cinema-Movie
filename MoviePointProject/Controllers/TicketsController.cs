using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MoviePoint.logic.Models;
using MoviePoint.logic.Repository;
using MoviePoint.logic.ViewModel;
using MoviePoint.Models;
using MoviePoint.Repository;

namespace MoviePoint.logic.Controllers
{
	public class TicketsController : Controller
	{

		ITicketsRepository ticketsRepository;
		IMovieRepository MovieRepository;
		ICinemaRepository CinemaRepository;
        private readonly UserManager<IdentityUser> userManager;

        MoviePointContext context;
		public TicketsController
			(ITicketsRepository _ticketsRepo, IMovieRepository _movieRepo, ICinemaRepository _cinemaRepo, MoviePointContext _context, UserManager<IdentityUser> _userManager)
		{
			ticketsRepository = _ticketsRepo;
			MovieRepository= _movieRepo;
			CinemaRepository= _cinemaRepo;
			context= _context;
			userManager= _userManager;
		}

		public IActionResult Index()
		{
			List<TicketsViewModel> ticketsViewModelsList = new List<TicketsViewModel>();
			List<Tickets> Tickets = ticketsRepository.GetAll();
			foreach(var item in Tickets)
			{
				TicketsViewModel ticketsViewModel = new TicketsViewModel();
				ticketsViewModel.price = MovieRepository.GetById(item.MovieID).Price;
				ticketsViewModel.Quantity = item.Quantity;
				ticketsViewModel.date = item.date;
				ticketsViewModel.CienmaName= CinemaRepository.GetById(item.CinemaID).Name;
				ticketsViewModel.MovieName= MovieRepository.GetById(item.MovieID).Name;
				ticketsViewModel.TotalPrice = item.price * item.Quantity;

				ticketsViewModel.userName = context.Users.FirstOrDefault(x => x.Id == item.userID).UserName;
				ticketsViewModelsList.Add(ticketsViewModel);
			}
			return View(ticketsViewModelsList);

		}

        public IActionResult SendPrice()
        {
           

            return View("Add");
        }
        public IActionResult SendPriceJSON(int MovieID)
        {
            double Moveprice= MovieRepository.GetById(MovieID).Price;

            return Json(Moveprice);
        }


        [HttpGet]
		public IActionResult Add()
		{
            TicketsViewModel ticketsViewModel=new TicketsViewModel();
			ticketsViewModel.MovieList = MovieRepository.GetAll();
            ticketsViewModel.CinemaList= CinemaRepository.GetAll();
           // ticketsViewModel.price = MovieRepository.GetByName(ticketsVM.MovieName).Price;

            return View(ticketsViewModel);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Add(TicketsViewModel ticketsVM)
		{
			if (ModelState.IsValid == true)
			{
				
				Tickets NewTicket = new Tickets();
				NewTicket.price = ticketsVM.price;//MovieRepository.GetByName(ticketsVM.MovieName).Price;

                NewTicket.date = ticketsVM.date;
				NewTicket.Quantity = ticketsVM.Quantity;
				NewTicket.CinemaID = int.Parse(ticketsVM.CienmaName); //CinemaRepository.GetByName(ticketsVM.CienmaName).Id;

                NewTicket.MovieID = int.Parse(ticketsVM.MovieName);//MovieRepository.GetByName(ticketsVM.MovieName).Id;
                NewTicket.userID = userManager.GetUserId(HttpContext.User);//context.Users.FirstOrDefault(x => x.UserName == ticketsVM.userName).Id;

                ticketsRepository.Insert(NewTicket);
				return RedirectToAction("Index");
			}

			return View(ticketsVM);



		}

		[HttpGet]
		public IActionResult Edit(int id)
		{
			Tickets tickets = ticketsRepository.GetById(id);
			return View(tickets);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Edit(int id, Tickets newtickets)
		{
			if (ModelState.IsValid == true)
			{
				ticketsRepository.Update(id, newtickets);
				return RedirectToAction("Index");
			}
			return View(newtickets);

		}

		public IActionResult Cancel(int id)
		{
			ticketsRepository.Delete(id);
			return RedirectToAction("Index");
		}

		
	}
}
