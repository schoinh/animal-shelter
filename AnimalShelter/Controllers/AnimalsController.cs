using Microsoft.AspNetCore.Mvc;
using AnimalShelter.Models;
using System.Collections.Generic;
using System.Linq;


namespace AnimalShelter.Controllers
{
    public class AnimalsController : Controller
    {
        private readonly AnimalShelterContext _db;

        public AnimalsController(AnimalShelterContext db)
        {
            _db = db;
        }

        public ActionResult Index()
        {
            // Using LINQ to order our list of animals by ascending alphaetical order of name (model.Name)
            List<Animal> model = _db.Animals.ToList();
            var query =
                from animal in model
                orderby animal.Name ascending
                select animal;
            return View(query.ToList());
        }

        // // IndexSort()  allows for user input to further refine results via their chosen species.
        // public ActionResult IndexSort(string species)
        // {

        //     List<Animal> model = _db.Animals.ToList();
        //     var query =
        //         from animal in model
        //         where animal.Species == species
        //         orderby animal.Name ascending
        //         select animal;
        //     return View(query.ToList());
        // }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Animal animal)
        {
            _db.Animals.Add(animal);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            Animal thisAnimal = _db.Animals.FirstOrDefault(animals => animals.AnimalId == id);
            return View(thisAnimal);
        }
    }
}