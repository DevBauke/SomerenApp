using SomerenApp.Models;
using Microsoft.AspNetCore.Mvc;
using SomerenApp.Repositories.Interfaces;
using System.Linq.Expressions;

namespace SomerenApp.Controllers
{
    public class LecturersController : Controller
    {
        private readonly ILecturersRepository _lecturersRepository;

        public LecturersController(ILecturersRepository lecturersRepository)
        {
            _lecturersRepository = lecturersRepository;
        }
        [HttpGet]
        public IActionResult Index()
        {
            try
            {
                List<Lecturer> lecturers = _lecturersRepository.GetAllLecturers();
                return View(lecturers);
            }
            catch (Exception ex)
            {
                ViewData["ErrorMessage"] = "LecturerIndex could not be loaded.";
                Console.WriteLine(ex.Message);
                return RedirectToAction("Index", "Home");
            }
        }
        [HttpGet]
        public ActionResult Create()
        {
            try
            {
                return View();
            }
            catch (Exception ex) 
            {
                ViewData["ErrorMessage"] = "LecturerCreate could not be loaded.";
                Console.WriteLine(ex.Message);
                return RedirectToAction("Index");
            }
        }
        [HttpPost]
        public ActionResult Create(Lecturer lecturer)
        {
            try
            {
                _lecturersRepository.AddLecturer(lecturer);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ViewData["ErrorMessage"] = "LecturerCreate failed to execute.";
                Console.WriteLine(ex.Message);
                return View(lecturer);
            }
        }
        [HttpGet]
        public ActionResult Delete(int? id)
        {
            try
            {
                if (id == null)
                {
                    throw new NullReferenceException();
                }
                Lecturer? lecturer = _lecturersRepository.GetLecturerByID((int)id);
                return View(lecturer);
            }
            catch (NullReferenceException ex)
            {
                ViewData["ErrorMessage"] = "Given lecturer ID does not exist.";
                Console.WriteLine(ex.Message);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ViewData["ErrorMessage"] = "LecturerDelete could not be loaded.";
                Console.WriteLine(ex.Message);
                return RedirectToAction("Index");
            }

        }
        [HttpPost]
        public ActionResult Delete(Lecturer lecturer)
        {
            try
            {
                _lecturersRepository.DeleteLecturer(lecturer);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ViewData["ErrorMessage"] = "LecturerDelete failed to execute.";
                Console.WriteLine(ex.Message);
                return View(lecturer);
            }
        }
        [HttpGet]
        public ActionResult Edit(int? id)
        {
            try
            {
                if (id == null)
                {
                    throw new NullReferenceException();
                }
                Lecturer? lecturer = _lecturersRepository.GetLecturerByID((int)id);
                return View(lecturer);
            }
            catch (NullReferenceException ex)
            {
                ViewData["ErrorMessage"] = "Given lecturer ID does not exist.";
                Console.WriteLine(ex.Message);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ViewData["ErrorMessage"] = "AccompanimentIndex could not be loaded.";
                Console.WriteLine(ex.Message);
                return RedirectToAction("Index");
            }

        }
        [HttpPost]
        public ActionResult Edit(Lecturer lecturer)
        {
            try
            {
                _lecturersRepository.EditLecturer(lecturer);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ViewData["ErrorMessage"] = "LecturerEdit failed to execute.";
                Console.WriteLine(ex.Message);
                return View(lecturer);
            }
        }
    }
}
