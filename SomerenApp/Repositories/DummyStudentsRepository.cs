﻿using SomerenApp.Models;

namespace SomerenApp.Repositories
{
    public class DBStudentsRepository : IStudentsRepository
    {
        List<Student> students =
            [
                new Student(734278, "Marilisa", "Kuilboer", "06-94846574", "1b", 1),
                new Student(728461, "Yasmina", "Baalla", "06-84659503", "1b", 2),
                new Student(735615, "Bauke", "Bosma", "06-253840281", "1b", 3)
            ];

        public List<Student> GetAll()
        {
            return students;
        }

        public void Add(Student student)
        {
            students.Add(student);
        }

       
        public Student? GetById(int studentNumber)
        {
            return students.FirstOrDefault(x => x.StudentNumber == studentNumber);
        }

        public void Delete(Student student)
        {
            throw new NotImplementedException();
        }

        public void Update(Student student)
        {
            throw new NotImplementedException();
        }

        public int GetAvailableRoomId()
        {
            throw new NotImplementedException();
        }
    }
}
