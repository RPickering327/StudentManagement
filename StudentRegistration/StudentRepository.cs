using CommonComponents;
using System;
using System.Data;
using System.Data.SqlClient;


namespace StudentRegistration
{
    public class StudentRepository
    {
        //Insert a student into the student database. Minimum requirements are firstname, lastname and address.
        public Student AddStudent(string firstName, string lastName, string Address, string studentType)
        {

            Student student = new Student();
            student.FirstName = firstName;
            student.LastName = lastName;
            student.StudentType = studentType.ToUpper();


            if (Validation.ValidationSuccessfully == true)
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
            else {

                Console.WriteLine(Validation.errorMessage); 
            }

            return student;
        }
        }
}


