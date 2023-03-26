using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MoviePoint.Models;
using MoviePoint.Repository;
using MoviePoint.ViewModel;
using NuGet.Protocol.Core.Types;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MoviePoint.Controllers
{
	
	public class MovieController : Controller
	{
		IMovieRepository movieRepository;
        IActorRepository actorRepository;
        ICommentsRepository commentsRepository;
        IProducerRepository producerRepository;
        ICinemaRepository cinemaRepository;
        IActorMovieRepository actormovieRepository;



        public MovieController
			(ICommentsRepository _comRepo,IMovieRepository _movRepo, IActorRepository _actRepo, IProducerRepository _proRepo, ICinemaRepository _cinemaRepo, IActorMovieRepository _actmovieRepo)
		{
            movieRepository = _movRepo;
            actorRepository = _actRepo;
            producerRepository = _proRepo;
            cinemaRepository = _cinemaRepo;
            actormovieRepository= _actmovieRepo;
            commentsRepository = _comRepo;
        }

		public IActionResult Index()
		{
			List<Movie> movies = movieRepository.GetAll();
			return View(movies);
		}

		public IActionResult Details(int id)
		{
            List<Comment> comments = commentsRepository.GetComments(id);
			ViewData["Comments"] = comments;
			MovieDetailsViewModel movieModel = new MovieDetailsViewModel();
			Movie movie = movieRepository.GetMovieWithDetails(id);
			movieModel.MovieName = movie.Name;
			movieModel.MovieCategory = movie.Category;
			movieModel.MoviePrice = movie.Price;
			movieModel.MovieEndDate = movie.EndtDate;
			movieModel.MovieStartDate = movie.StartDate;
			movieModel.MovieDescription = movie.Description;
			movieModel.MovieImageUrl = movie.ImageUrl;
			movieModel.CinemaName = movie.Cinema.Name;
			movieModel.CinemaLocation = movie.Cinema.Location;
			movieModel.ProducerName = movie.Producer.FullName;
            
			return View(movieModel);
		}

        [HttpGet]
        public IActionResult Insert()
        {
            MoiveViewModel NewMoive =
                new MoiveViewModel();

           // NewMoive.ActorsObj = actorRepository.GetAll();
            NewMoive.cinemas = cinemaRepository.GetAll();
            NewMoive.producers = producerRepository.GetAll();
            NewMoive.Actor_Movies = actormovieRepository.GetAll();
            NewMoive.AllActors = actorRepository.GetAll();


            return View(NewMoive);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Insert(MoiveViewModel moiveViewModel)
        {
            
            if (ModelState.IsValid == true)
            {
                Movie movie = new Movie();

                movie.Name = moiveViewModel.Name;
                movie.Description = moiveViewModel.Description;
                movie.Price =(int) moiveViewModel.Price;
                movie.ImageUrl = moiveViewModel.ImageUrl;
                movie.StartDate = moiveViewModel.StartDate;
                movie.EndtDate = moiveViewModel.EndtDate;
                movie.ProducerID = moiveViewModel.ProducerID;
                movie.CinemaID = moiveViewModel.CinemaID;
                movie.Category=moiveViewModel.Category;
                movie.videoURL = moiveViewModel.videoURL;
                moiveViewModel.AllActors = actorRepository.GetAll();
                moiveViewModel.cinemas = cinemaRepository.GetAll();
                moiveViewModel.producers = producerRepository.GetAll();
                moiveViewModel.Actor_Movies = actormovieRepository.GetAll();
              

                movieRepository.Insert(movie);

                List<Actor> actors = new List<Actor>();
                foreach (var ctorid in moiveViewModel.Actors)
                {
                    
                    actors.Add( actorRepository.GetById(ctorid));

                }
                moiveViewModel.ActorsObj = actors;


                foreach (var actorId in moiveViewModel.Actors)
                {
                    var newActorMovie = new Actor_Movie()
                    {
                        MovieID = movie.Id,
                        ActorID = actorId
                    };
                    actormovieRepository.Insert(newActorMovie);
                }
                return RedirectToAction("Index");
            }

            return View(moiveViewModel);
        }



        [HttpGet]
        public IActionResult Update(int id)
        {
            var movie = movieRepository.GetById(id);

            MoiveViewModel NewMoive =
                new MoiveViewModel();
            NewMoive.Name= movie.Name;
            NewMoive.Description = movie.Description;
            NewMoive.Price = movie.Price;
            NewMoive.ImageUrl = movie.ImageUrl;
            NewMoive.StartDate = movie.StartDate;
            NewMoive.EndtDate = movie.EndtDate;
            NewMoive.Category = movie.Category;
            NewMoive.videoURL = movie.videoURL;
            NewMoive.CinemaID = movie.CinemaID;
            NewMoive.ProducerID = movie.ProducerID;

            // NewMoive.ActorsObj = actorRepository.GetAll();
            NewMoive.cinemas = cinemaRepository.GetAll();
            NewMoive.producers = producerRepository.GetAll();
            NewMoive.Actor_Movies = actormovieRepository.GetAll();
            NewMoive.AllActors = actorRepository.GetAll();

            return View(NewMoive);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(MoiveViewModel moiveViewModel, [FromRoute] int id)
        {
            Movie oldMovie = movieRepository.GetById(id);

            if (ModelState.IsValid == true)
            {
                oldMovie.Name = moiveViewModel.Name;
                oldMovie.Description = moiveViewModel.Description;
                oldMovie.Price = (int)moiveViewModel.Price;
                oldMovie.ImageUrl = moiveViewModel.ImageUrl;
                oldMovie.StartDate = moiveViewModel.StartDate;
                oldMovie.EndtDate = moiveViewModel.EndtDate;
                oldMovie.ProducerID = moiveViewModel.ProducerID;
                oldMovie.CinemaID = moiveViewModel.CinemaID;
                oldMovie.Category = moiveViewModel.Category;
                oldMovie.videoURL = moiveViewModel.videoURL;

                moiveViewModel.AllActors = actorRepository.GetAll();
                moiveViewModel.cinemas = cinemaRepository.GetAll();
                moiveViewModel.producers = producerRepository.GetAll();
                moiveViewModel.Actor_Movies = actormovieRepository.GetAll();


                movieRepository.Update(id,oldMovie);

                List<Actor> actors = new List<Actor>();
                foreach (var ctorid in moiveViewModel.Actors)
                {

                    actors.Add(actorRepository.GetById(ctorid));

                }
                moiveViewModel.ActorsObj = actors;


                foreach (var actorId in moiveViewModel.Actors)
                {
                    var newActorMovie = new Actor_Movie()
                    {
                        MovieID = oldMovie.Id,
                        ActorID = actorId
                    };
                    actormovieRepository.Update(id,newActorMovie);
                }
                return RedirectToAction("Index");
            }

            return View(moiveViewModel);
        }

        public IActionResult Delete(int id)
        {
            //MoiveViewModel NewMoive =
            //   new MoiveViewModel();
          //  Movie movie= movieRepository.GetById(id);
			//NewMoive.Name = movie.Name;
			//NewMoive.Description = movie.Description;
			//NewMoive.Price = movie.Price;
			//NewMoive.ImageUrl = movie.ImageUrl;
			//NewMoive.StartDate = movie.StartDate;
			//NewMoive.EndtDate = movie.EndtDate;
			//NewMoive.ProducerID = movie.ProducerID;
			//NewMoive.CinemaID = movie.CinemaID;
			//NewMoive.Category = movie.Category;
			//NewMoive.videoURL = movie.videoURL;

            List<Actor_Movie> ActorMovie= actormovieRepository.GetByMovieId(id);


			foreach (var actor in ActorMovie)
			{
				//Movie movie = new Movie();

    //            var newActorMovie = new Actor_Movie()
    //            {
    //                MovieID = actor.MovieID,
    //                ActorID = actor.ActorID
				//};
				actormovieRepository.Delete(actor.ID);
			}
			 movieRepository.Delete(id);

			return RedirectToAction("Index");
        }
    }
}
