namespace SomerenApp.Repositories.Interfaces
{
    public interface IAccompanimentsRepository
    {
        void AddSuperVisor(int activityNumber, int lecturerNumber);
        void RemoveSuperVisor(int activityNumber, int lecturerNumber);
    }
}