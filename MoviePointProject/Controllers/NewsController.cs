
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MoviePoint.Models;
using MoviePoint.Repository;
using MoviePoint.ViewModel;


namespace MoviePoint.Controllers
{
	public class NewsController : Controller
	{
		IMovieRepository movieRepository;
		ICommentsRepository commentsRepository;
		private readonly UserManager<IdentityUser> userManager;


		public NewsController
			(ICommentsRepository _comRepo, IMovieRepository _movRepo, UserManager<IdentityUser> _userManager)
		{
			movieRepository = _movRepo;
			commentsRepository = _comRepo;
			this.userManager = _userManager;
		}

		public IActionResult Index()
		{
			List<Movie> movies = movieRepository.GetAll();
			return View(movies);
		}

		public IActionResult Details(int id)
		{
            MovieWithUserViewModel movieWithUserViewModel = new MovieWithUserViewModel();
			string userId = userManager.GetUserId(HttpContext.User);

			Movie movie = movieRepository.GetMovieWithDetails(id);
            movieWithUserViewModel.Movie= movie;
			movieWithUserViewModel.UserID = userId;
			movieWithUserViewModel.Comments = commentsRepository.GetComments(id);


			return View(movieWithUserViewModel); //movie
        }
	}
}
