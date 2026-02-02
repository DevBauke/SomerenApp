namespace SomerenApp.Models.ViewModels
{
    public class AccompanimentCreateDeleteViewModel
    {
        public Lecturer Lecturer { get; set; }
        public Activity Activity { get; set; }
        public AccompanimentCreateDeleteViewModel()
        {
            
        }

        public AccompanimentCreateDeleteViewModel(Lecturer lecturer, Activity activity)
        {
            Lecturer = lecturer;
            Activity = activity;
        }
    }
}
