using CommonComponents;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static System.Console; 


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

            if (Validation.ValidationSuccessfully == true)
            {
                using (SqlConnection connection = new SqlConnection(Helper.ConnectionValue("StudentDB")))
                {
                    using (SqlCommand command = new SqlCommand())
                    {
                        command.Connection = connection;
                        command.CommandType = CommandType.Text;
                        command.CommandText = "INSERT into EnrolledStudents (StudentId, CourseId) VALUES (@StudentId, @CourseId)";
                        command.Parameters.AddWithValue("@StudentId", studentID);
                        command.Parameters.AddWithValue("@CourseId", courseID);
              
                        try
                        {
                            connection.Open();
                            int recordsAffected = command.ExecuteNonQuery();
                        }
                        catch (SqlException)
                        {
                            WriteLine("Either the course or the student are not in the DB.");
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

        }

        //Check the inputted grade for the student is greater than the course minimum if not return false so the user is not inserted into the database.
        public bool CheckGrade(int courseId, int studentID)
        {
            using (SqlConnection connection = new SqlConnection(Helper.ConnectionValue("StudentDB")))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = $"SELECT g.*, c.*, s.* FROM Grades g, Student s, Courses c WHERE {studentID} = g.StudentId" +
                                          $" AND s.StudentId = {studentID}" +
                                          $" AND c.CourseId = {courseId}" +
                                          " AND c.MinimumGrade < g.StudentGrade;";
                    try
                    {
                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();

                        int numberOfRows = reader.Cast<object>().Count();

                        if (!(numberOfRows == 1))
                        {
                            Validation.ValidationSuccessfully = false;
                            WriteLine("Didn't meet the minimum grades to join this course.");
                        }

                        reader.Close();
                    }
                    catch
                    {

                    }

                }
            }

            return Validation.ValidationSuccessfully;

        }

    }
}
