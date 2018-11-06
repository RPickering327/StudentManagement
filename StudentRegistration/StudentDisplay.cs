using CommonComponents;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentRegistration
{
    class StudentDisplay
    {

        public void DisplayStudentWithACourse()
        {
            using (SqlConnection connection = new SqlConnection(Helper.ConnectionValue("StudentDB")))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "SELECT A.* FROM Student A INNER JOIN EnrolledStudents B on A.StudentId = B.StudentId where B.StudentId = A.StudentId"; 
                   try
                    {
                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();

                        Console.WriteLine("First name".PadLeft(10) + "Last name".PadLeft(10) + "Address".PadLeft(52) + "Student Type".PadLeft(20));
                        while (reader.Read())
                        {
                            Console.WriteLine(reader["FirstName"].ToString().PadLeft(10) + " " + reader["LastName"].ToString().PadLeft(10) + " " + reader["Address"].ToString().PadLeft(50) + " " + reader["StudentType"].ToString().PadLeft(10));
                        }
                        reader.Close();
                    }
                    catch {

                    }
               
                }
            }
        
        }

        public void DisplayAllForeignOrPhdStudents(string studentType)
        {
            using (SqlConnection connection = new SqlConnection(Helper.ConnectionValue("StudentDB")))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = $"SELECT * FROM Student WHERE StudentType = '{studentType}'";
                    try
                    {
                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();

                        Console.WriteLine("First name".PadLeft(10) + "Last name".PadLeft(10) + "Address".PadLeft(52) + "Student Type".PadLeft(20));
                        while (reader.Read())
                        {
                            Console.WriteLine(reader["FirstName"].ToString().PadLeft(10) + " " + reader["LastName"].ToString().PadLeft(10) + " " + reader["Address"].ToString().PadLeft(50) + " " + reader["StudentType"].ToString().PadLeft(10));
                        }
                        reader.Close();
                    }
                    catch
                    {

                    }

                }
            }

        }
    }
}
