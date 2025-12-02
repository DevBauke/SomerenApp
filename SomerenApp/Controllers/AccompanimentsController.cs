using Microsoft.AspNetCore.Mvc;
using SomerenApp.Models;
using SomerenApp.Repositories;

namespace SomerenApp.Controllers
{
    public class AccompanimentsController : Controller
    {
        private readonly IActivitiesRepository _activitiesRepository;
        private readonly ILecturersRepository _lecturersRepository;
        //private readonly IAccompanimentsRepository _accompanimentsRepository;

        public AccompanimentsController(IActivitiesRepository activities, ILecturersRepository lecturersRepository) //, IAccompanimentsRepository accompanimentsRepository
        {
            _activitiesRepository = activities;
            _lecturersRepository = lecturersRepository;
            //_accompanimentsRepository = accompanimentsRepository;
        }
        [HttpGet]
        public ActionResult Index(int? activityNumber)
        {
            try
            {
                if (activityNumber == null)
                {
                    return View();
                }
                Models.Activity activity = _activitiesRepository.GetByID((int)activityNumber);
                List<Lecturer> supervisors = _lecturersRepository.GetSupervisors(activity.ActivityNumber);
                List<Lecturer> nonSupervisors = _lecturersRepository.GetNonSupervisors(activity.ActivityNumber);

                AccompanimentIndexViewModel accompaniment = new AccompanimentIndexViewModel(activity, supervisors, nonSupervisors);

                return View(accompaniment);
            }
            catch (Exception ex)
            {
                ViewData["ErrorMessage"] = ex.Message;
                return RedirectToAction("Index");
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
            catch 
            { 
                return View("Index");
            }
            
        }

        [HttpPost]
        public ActionResult Delete(AccompanimentCreateDeleteViewModel accompanimentCreateDeleteViewModel)
        {
            try
            {
                _lecturersRepository.RemoveSuperVisor(accompanimentCreateDeleteViewModel);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ViewData["ErrorMessage"] = ex.Message;
                return View("Index");
            }
        }
        
        [HttpGet]
        public ActionResult Create(int activityNumber, int lecturerNumber)
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(AccompanimentCreateDeleteViewModel accompanimentCreateDeleteViewModel)
        {
            try
            {
                _lecturersRepository.AddSuperVisor(accompanimentCreateDeleteViewModel);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ViewData["ErrorMessage"] = ex.Message;
                return View("Index");
            }
        }
    }
}
