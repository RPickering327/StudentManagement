using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentRegistration
{
    public class UserSelection
    {

        public UserSelection()
        {
            //By default the user does not want to exit the application 
            ExitApplication = false;
        }

        public bool ExitApplication { get; set; }

        public void DisplayUserOptions() {
            //Displays the list of options to the user. Clears it at first to ensure all other text is kept
            // of the screen and not in the users face.
            Console.Clear();
            Console.WriteLine("Please select an option between 1-6");
            Console.WriteLine("1. Add a new student to the database");
            Console.WriteLine("2. Add a student to a course");
            Console.WriteLine("3. Add a course");
            Console.WriteLine("4. View all students on each course");
            Console.WriteLine("5. List all foreign students");
            Console.WriteLine("6. List all PHD students");
            Console.WriteLine("7. Exit Application");

        }

        public void UsersInput(string userInput)
        {
            if (userInput == "1")
            {
                var newStudent = new StudentRepository();

                Console.WriteLine("Please enter the students first name");
                var firstName = Console.ReadLine();

                Console.WriteLine("Please enter the students last name");
                var lastName = Console.ReadLine();

                Console.WriteLine("Please enter the students address");
                var address = Console.ReadLine();

                Console.WriteLine("Please enter the student student type");
                Console.WriteLine("U = Undergraduate, P = Postgraduate, F = Foreign student");
                var studentType = Console.ReadLine();

                newStudent.AddStudent(firstName, lastName, address, studentType);
                newStudent.UpdateGrade(55);
            }
            else if (userInput == "2")
            {
                var newCourse = new CourseRepository();

                Console.WriteLine("Please enter the course ID");
                var courseID = Console.ReadLine();

                Console.WriteLine("Please enter the student ID");
                var studentID = Console.ReadLine();

                newCourse.AddStudentToCourse(int.Parse(courseID), int.Parse(studentID));

            }
            else if (userInput == "3")
            {
                var newCourse = new CourseRepository();

                Console.WriteLine("Please enter the coursename");
                var courseName = Console.ReadLine();

                Console.WriteLine("Please enter the minimum percentage grade 1-100");
                var minimumGrade = Console.ReadLine();

                newCourse.AddNewCourse(courseName, int.Parse(minimumGrade));

            }
            else if (userInput == "7")
            {
                ExitApplication = true;
            }

        }

        
    }
}
