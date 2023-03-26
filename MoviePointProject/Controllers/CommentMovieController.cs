using Microsoft.AspNetCore.Mvc;
using MoviePoint.Models;

using Microsoft.AspNetCore.SignalR;
using MoviePoint.Hubs;
using MoviePoint.Repository;

namespace MoviePoint.Controllers
{
    public class CommentMovieController : Controller
    {

        MoviePointContext context = new MoviePointContext();
        IHubContext<MovieHub> hubContext;
        IMovieRepository movieRepository;
        ICommentsRepository commentsRepository;
      


        public CommentMovieController(IHubContext<MovieHub> hubContext, IMovieRepository _movRepo, ICommentsRepository _commentsRepo)
        {
            this.hubContext = hubContext;
            movieRepository = _movRepo;
            commentsRepository = _commentsRepo;
        }
        public IActionResult Index()
        {
            List<Comment> comments = commentsRepository.GetAll();
            return View(comments);
        }
        public IActionResult NewComment()
        {

            return View();
        }
        [HttpPost]
        public IActionResult NewComment(string name, string text)//Comment comment)
        {
            //commentsRepository.Insert(comment);
            //notify 
            hubContext.Clients.All.SendAsync("NewComment", name, text);
            return RedirectToAction("Index");
            //return View();
        }

       




	}
}
