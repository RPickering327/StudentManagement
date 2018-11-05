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
    public class GradeRepository
    {
        public void UpdateGrade(int studentGrade, int studentId)
        {
            using (SqlConnection connection = new SqlConnection(Helper.ConnectionValue("StudentDB")))
            {
                using (SqlCommand command = new SqlCommand())
                {

                    command.Connection = connection;
                    command.CommandText = $"UPDATE Grades SET StudentGrade = {studentGrade} WHERE StudentId = {studentId};";
                    command.CommandType = CommandType.Text;

                    try
                    {
                        connection.Open();
                        int recordsAffected = command.ExecuteNonQuery();
                    }
                    catch (SqlException)
                    {

                    }
                }



            }

        }
    }
}