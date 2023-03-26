using Microsoft.AspNetCore.Mvc;
using MoviePoint.Models;
using MoviePoint.Repository;

namespace MoviePoint.Controllers
{
    public class CinemaController : Controller
    {
        ICinemaRepository cinemaRepository;

        public CinemaController
            (ICinemaRepository _cinRepo)
        {
            cinemaRepository = _cinRepo;
        }

        public IActionResult Index()
        {
            List<Cinema> cinema = cinemaRepository.GetAll();
            return View(cinema);

        }

        [HttpGet]
        public IActionResult Insert()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Insert(Cinema cinema)
        {
            if (ModelState.IsValid == true)
            {
                Cinema NewCinema = new Cinema();
                NewCinema.Name = cinema.Name;
                NewCinema.Logo = cinema.Logo;
                NewCinema.Description = cinema.Description;
                NewCinema.Movies = cinema.Movies;
                NewCinema.Location = cinema.Location;
                cinemaRepository.Insert(NewCinema);
                return RedirectToAction("Index");
            }

            return View(cinema);



        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            Cinema cinema = cinemaRepository.GetById(id);
            return View(cinema);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(Cinema newCinema, [FromRoute] int id)
        {
            if (ModelState.IsValid == true)
            {
                cinemaRepository.Update(id, newCinema);
                return RedirectToAction("Index");
            }
            return View(newCinema);

        }

        public IActionResult Delete(int id)
        {
            cinemaRepository.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
