﻿using SomerenApp.Models;
using System.Collections.Generic;

namespace SomerenApp.Repositories
{
    public interface IActivitiesRepository
    {
        List<Activity> GetAllActivities();
        Activity? GetByID(int activityNumber); //specific activity
        void Add(Activity activity);
        void Update(Activity activity);
        void Delete(Activity activity);
        void UpdateAccompaniments(Accompaniment accompaniment);
        List <Lecturer> GetSupervisors(int activityNumber);
        List<Lecturer> GetNonSupervisors(int activityNumber);
    }
}
