using Microsoft.AspNetCore.Mvc;
using SomerenApp.Models;
using SomerenApp.Models.ViewModels;
using SomerenApp.Repositories.Interfaces;

namespace SomerenApp.Controllers
{
    public class AccompanimentsController : Controller
    {
        private readonly IActivitiesRepository _activitiesRepository;
        private readonly ILecturersRepository _lecturersRepository;
        //private readonly IAccompanimentsRepository _accompanimentsRepository;

        public AccompanimentsController(IActivitiesRepository activities, ILecturersRepository lecturersRepository)
        {
            _activitiesRepository = activities;
            _lecturersRepository = lecturersRepository;
        }
        [HttpGet]
        public ActionResult Index(int? activityNumber)
        {
            try
            {
                if (activityNumber == null)
                {
                    Console.WriteLine("activityNumber == null");
                }
                else
                {
                    Console.WriteLine($"activityNumber == {activityNumber}");
                }

                Activity activity = _activitiesRepository.GetByID((int)activityNumber);
                Console.WriteLine(activity);

                List<Lecturer> supervisors = _lecturersRepository.GetSupervisors(activity.ActivityNumber);
                Console.WriteLine("supervisors:");
                foreach (Lecturer lecturer in supervisors) { Console.WriteLine(lecturer); }

                List<Lecturer> nonSupervisors = _lecturersRepository.GetNonSupervisors(activity.ActivityNumber);
                Console.WriteLine("nonSupervisors:");
                foreach (Lecturer lecturer in nonSupervisors) { Console.WriteLine(lecturer); }
                AccompanimentIndexViewModel accompaniment = new AccompanimentIndexViewModel(activity, supervisors, nonSupervisors);

                return View(accompaniment);
            }
            catch (Exception ex)
            {
                ViewData["ErrorMessage"] = "AccompanimentIndex could not be loaded.";
                Console.WriteLine(ex.Message);
                return RedirectToAction("Index", "Activities");
            }
        }
        [HttpGet]
        public ActionResult Delete(int LId, int AId)
        {
            try
            {
                Lecturer lecturer = _lecturersRepository.GetLecturerByID(LId);
                Activity activity = _activitiesRepository.GetByID(AId);
                AccompanimentCreateDeleteViewModel accompanimentCreateDeleteViewModel = new(lecturer, activity);
                return View(accompanimentCreateDeleteViewModel);
            }
            catch (Exception ex)
            {
                ViewData["ErrorMessage"] = "AccompanimentDelete could not be loaded.";
                Console.WriteLine(ex.Message);
                return RedirectToAction("Index", "Accompaniments", new { activityNumber = AId });
            }

        }

        [HttpPost]
        public ActionResult Delete(AccompanimentCreateDeleteViewModel accompanimentCreateDeleteViewModel)
        {
            try
            {
                _lecturersRepository.RemoveSuperVisor(accompanimentCreateDeleteViewModel);
                return RedirectToAction("Index", "Accompaniments", new { activityNumber = accompanimentCreateDeleteViewModel.Activity.ActivityNumber });
            }
            catch (Exception ex)
            {
                ViewData["ErrorMessage"] = "DeleteAccompaniment failed to execute.";
                Console.WriteLine(ex.Message);
                return RedirectToAction("Index", "Accompaniments", new { activityNumber = accompanimentCreateDeleteViewModel.Activity.ActivityNumber });
            }
        }

        [HttpGet]
        public ActionResult Create(int AId, int LId)
        {
            try
            {
                Lecturer lecturer = _lecturersRepository.GetLecturerByID(LId);
                Activity activity = _activitiesRepository.GetByID(AId);
                AccompanimentCreateDeleteViewModel accompanimentCreateDeleteViewModel = new(lecturer, activity);

                return View(accompanimentCreateDeleteViewModel);
            }
            catch (Exception ex)
            {
                ViewData["ErrorMessage"] = "CreateAccompaniment could not be loaded.";
                Console.WriteLine(ex.Message);
                return RedirectToAction("Index", "Accompaniments", new { activityNumber = AId }); ;
            }
        }

        [HttpPost]
        public ActionResult Create(AccompanimentCreateDeleteViewModel accompanimentCreateDeleteViewModel)
        {
            try
            {
                _lecturersRepository.AddSuperVisor(accompanimentCreateDeleteViewModel);
                return RedirectToAction("Index", "Accompaniments", new { activityNumber = accompanimentCreateDeleteViewModel.Activity.ActivityNumber });
            }
            catch (Exception ex)
            {
                ViewData["ErrorMessage"] = "CreateAccompaniment failed to execute.";
                Console.WriteLine(ex.Message);
                return RedirectToAction("Index", "Accompaniments", new { activityNumber = accompanimentCreateDeleteViewModel.Activity.ActivityNumber });
            }
        }
    }
}