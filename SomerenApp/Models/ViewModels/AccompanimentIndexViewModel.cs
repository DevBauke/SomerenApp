namespace SomerenApp.Models.ViewModels
{
    public class AccompanimentIndexViewModel
    {
        public Activity Activity {  get; set; }
        public List<Lecturer> Supervisors { get; set; }
        public List<Lecturer> NonSupervisors { get; set; }
        public AccompanimentIndexViewModel()
        {
            
        }

        public AccompanimentIndexViewModel(Activity activity, List<Lecturer> supervisors, List<Lecturer> nonSupervisors)
        {
            Activity = activity;
            Supervisors = supervisors;
            NonSupervisors = nonSupervisors;
        }
    }
}
