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
    public class StudentRepository
    {
        //Insert a student into the student database. Minimum requirements are firstname, lastname and address.
        public void AddStudent(string firstName, string lastName, string Address, string studentType)
        {
            using (SqlConnection connection = new SqlConnection(Helper.ConnectionValue("StudentDB")))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "INSERT into Student (FirstName, LastName, Address, StudentType) VALUES (@FirstName, @LastName, @Address, @StudentType)";
                    command.CommandType = CommandType.Text;
                    command.Parameters.AddWithValue("@FirstName", firstName);
                    command.Parameters.AddWithValue("@LastName", lastName);
                    command.Parameters.AddWithValue("@Address", Address);
                    command.Parameters.AddWithValue("@StudentType", studentType);
                 
                    try
                    {
                        connection.Open();
                        int recordsAffected = command.ExecuteNonQuery();
                    }
                    catch (SqlException)
                    {
                        // Add a logger class that outputs to the logger if an error is caught here.
                    }
                }

            }
        }
        }
}


