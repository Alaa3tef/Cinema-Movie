using Microsoft.AspNetCore.Mvc;
using MoviePoint.Models;
using MoviePoint.Repository;

namespace MoviePoint.Controllers
{
    public class ProducerController : Controller
    {
        IProducerRepository producerRepository;

        public ProducerController
            (IProducerRepository _proRepo)
        {
            producerRepository = _proRepo;
        }

        public IActionResult Index()
        {
            List<Producer> producer = producerRepository.GetAll();
            return View(producer);

        }

        [HttpGet]
        public IActionResult Insert()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Insert(Producer producer)
        {
            if (ModelState.IsValid == true)
            {
                Producer NewProducer = new Producer();
                NewProducer.FullName = producer.FullName;
                NewProducer.Bio = producer.Bio;
                NewProducer.ProfilePicture = producer.ProfilePicture;

                producerRepository.Insert(NewProducer);
                return RedirectToAction("Index");
            }

            return View(producer);



        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            Producer producer = producerRepository.GetById(id);
            return View(producer);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(Producer newProducer, [FromRoute] int id)
        {
            if (ModelState.IsValid == true)
            {
                producerRepository.Update(id, newProducer);
                return RedirectToAction("Index");
            }
            return View(newProducer);

        }

        public IActionResult Delete(int id)
        {
            producerRepository.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
