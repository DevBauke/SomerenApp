/*using Microsoft.Data.SqlClient;
using SomerenApp.Models;

namespace SomerenApp.Repositories
{
    public class DbAccompanimentsRepository : IAccompanimentsRepository
    {
        private readonly string? _connectionString;

        public DbAccompanimentsRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("SomerenDatabase");
        }

        public void AddSuperVisor(int activityNumber, int lecturerNumber)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = $"DELETE FROM accompaniments WHERE activityNumber = @ActivityNumber AND lecturerNumber = @LecturerNumber";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ActivityNumber", activityNumber);
                command.Parameters.AddWithValue("@LecturerNumber", lecturerNumber);
                command.Connection.Open();
                int nrofRowsAffected = command.ExecuteNonQuery();
                if (nrofRowsAffected == 0)
                {
                    throw new Exception("No records updated!");
                }
            }
        }
        public void RemoveSuperVisor(int activityNumber, int lecturerNumber)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = $"INSERT INTO accompaniments (activityNumber, lecturerNumber)" +
                    "VALUES(@ActivityNumber, @LecturerNumber);";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ActivityNumber", activityNumber);
                command.Parameters.AddWithValue("@LecturerNumber", lecturerNumber);
                command.Connection.Open();
            }
        }

        public List<Lecturer> GetSupervisors(int activityNumber)
        {
            return AddLecturersToActivityList("SELECT * FROM lecturers WHERE lecturerNumber NOT IN  (SELECT lecturerNumber FROM accompaniments WHERE activityNumber = @ActivityNumber;);", activityNumber);
        }
        public List<Lecturer> GetNonSupervisors(int activityNumber)
        {
            return AddLecturersToActivityList("SELECT lecturerNumber FROM accompaniments WHERE @ActivityNumber = @ActivityNumber;", activityNumber);
        }
        public List<Accompaniment> GetAllAccompaniments()
        {

        }
        private Lecturer ReadAccompaniment(SqlDataReader reader)
        {
            Activity activity = Activity.((int)reader["activityNumber"]);
            string firstName = (string)reader["firstName"];
            return new Accompaniment(lecturerNumber, firstName);
        }
        public List<Lecturer> AddLecturersToActivityList(string query, int activityNumber)
        {
            List<Lecturer> lecturers = new List<Lecturer>();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ActivityNumber", activityNumber);
                command.Connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Lecturer lecturer = ReadLecturer(reader);
                    lecturers.Add(lecturer);
                }
            }
            return lecturers;

        }
    }*/
