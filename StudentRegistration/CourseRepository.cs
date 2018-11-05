using CommonComponents;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace StudentRegistration
{
    class CourseRepository
    {

        //Insert a new course into the the database.
        public void AddNewCourse(string courseName, int minimumGrade)
        {
            using (SqlConnection connection = new SqlConnection(Helper.ConnectionValue("StudentDB")))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType = CommandType.Text;
                    command.CommandText = "INSERT into Courses (CourseName, MinimumGrade) VALUES (@CourseName, @MinimumGrade)";
                    command.Parameters.AddWithValue("@CourseName", courseName);
                    command.Parameters.AddWithValue("@MinimumGrade", minimumGrade);
                    try
                    {
                        connection.Open();
                        int recordsAffected = command.ExecuteNonQuery();
                    }
                    catch (SqlException)
                    {
                        // Add a logger class that outputs to the logger if an error is caught here.
                    }
                    finally
                    {
                        connection.Close();
                    }
                }


            }
        }


        //Add the student to the course 
        public void AddStudentToCourse(int studentID, int courseID) {


            using (SqlConnection connection = new SqlConnection(Helper.ConnectionValue("StudentDB")))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType = CommandType.Text;
                    command.CommandText = "INSERT into EnrolledStudents (StudentId, CourseId) VALUES (@StudentId, @CourseId)";
                    command.Parameters.AddWithValue("@CourseId", courseID);
                    command.Parameters.AddWithValue("@StudentId", studentID);
                    try
                    {
                        connection.Open();
                        int recordsAffected = command.ExecuteNonQuery();
                    }
                    catch (SqlException)
                    {
                        Console.WriteLine("Either the course or the student are not in the DB.");
                        int milliseconds = 2000;
                        Thread.Sleep(milliseconds);
                    }
                    finally
                    {
                        connection.Close();
                    }
                }


            }

        }

        public bool CheckGrade(int studentGrade, int studentID)
        {
            bool meetsCriteria = true;

            using (SqlConnection connection = new SqlConnection(Helper.ConnectionValue("StudentDB")))
            {
                using (SqlCommand command = new SqlCommand())
                {

                    command.Connection = connection;
                    command.CommandType = CommandType.Text;
                    command.CommandText = "SELECT * FROM Grades where StudentId = '@StudentId';";
                    command.Parameters.AddWithValue("@StudentId", studentID);

                }
            }

                    return meetsCriteria;
        }

    }
}
