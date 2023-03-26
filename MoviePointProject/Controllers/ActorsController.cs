using Microsoft.AspNetCore.Mvc;
using MoviePoint.Models;
using MoviePoint.Repository;

namespace MoviePoint.Controllers
{
    public class ActorsController : Controller
    {

        IActorRepository actorRepository;

        public ActorsController
            (IActorRepository _actRepo)
        {
            actorRepository = _actRepo;
        }

        public IActionResult Index()
        {
            List<Actor> actors = actorRepository.GetAll();
            return View(actors);
           
        }

        [HttpGet]
        public IActionResult Insert()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Insert(Actor Act)
        {
            if (ModelState.IsValid == true)
            {
                Actor NewActor = new Actor();
                NewActor.FullName = Act.FullName;
                NewActor.ProfilePicUrl = Act.ProfilePicUrl;
                NewActor.Bio = Act.Bio;
                actorRepository.Insert(NewActor);
                return RedirectToAction("Index");
            }
           
                return View(Act);
            
           
            
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            Actor Act = actorRepository.GetById(id);
            return View(Act);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update( int id, Actor newActor)
        {
            if (ModelState.IsValid == true)
            {
                actorRepository.Update(id,newActor);
                return RedirectToAction("Index");
            }
                return View(newActor);
                
        }

        public IActionResult Delete(int id)
        {
            actorRepository.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
