using CommonComponents;
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

        //Displays the list of options to the user. Clears it at first to ensure all other text is kept
        // of the screen and not in the users face.
        public void DisplayUserOptions() {
           
            Validation.errorMessage = "";
            Console.WriteLine("Please select an option between 1-6");
            Console.WriteLine("1. Add a new student to the database");
            Console.WriteLine("2. Add a student to a course");
            Console.WriteLine("3. Add a course");
            Console.WriteLine("4. Update grades");
            Console.WriteLine("5. View all students on each course");
            Console.WriteLine("6. List all foreign students");
            Console.WriteLine("7. List all PHD students");
            Console.WriteLine("8. Exit Application");

        }

      
        public void UsersInput(string userInput)
        {
            //Takes the user input from the console and then proceeds to action what they want to do.
            if (userInput == "1")
            {
                Console.WriteLine("Please enter the students first name");
                var firstName = Console.ReadLine();

                Console.WriteLine("Please enter the students last name");
                var lastName = Console.ReadLine();

                Console.WriteLine("Please enter the students address");
                var address = Console.ReadLine();

                Console.WriteLine("Please enter the student student type");
                Console.WriteLine("U = Undergraduate, P = Postgraduate, F = Foreign student");
                var studentType = Console.ReadLine();

                var newStudent = new StudentRepository();
                newStudent.AddStudent(firstName, lastName, address, studentType);
            }
            else if (userInput == "2")
            {

                Console.WriteLine("Please enter the course ID");
                var courseID = Console.ReadLine();

                Console.WriteLine("Please enter the student ID");
                var studentID = Console.ReadLine();

                var newCourse = new CourseRepository();
                newCourse.AddStudentToCourse(int.Parse(courseID), int.Parse(studentID));

            }
            else if (userInput == "3")
            {
               

                Console.WriteLine("Please enter the coursename");
                var courseName = Console.ReadLine();

                Console.WriteLine("Please enter the minimum percentage grade 1-100");
                var minimumGrade = Console.ReadLine();

                var newCourse = new CourseRepository();
                newCourse.AddNewCourse(courseName, int.Parse(minimumGrade));

            }
            else if (userInput == "4")
            {
              
             
                Console.WriteLine("Please enter the student ID");
                var studentId = Console.ReadLine();

                Console.WriteLine("Please enter thier grade");
                var studentGrade = Console.ReadLine();

                var updateGrade = new GradeRepository();
                updateGrade.UpdateGrade(int.Parse(studentGrade), int.Parse(studentId));

            }
            else if (userInput == "5")
            {
                var studentDisplay = new StudentDisplay();
                studentDisplay.DisplayStudentWithACourse();

            }
            else if (userInput == "6")
            {
                var studentDisplay = new StudentDisplay();
                studentDisplay.DisplayAllForeignOrPhdStudents("F");

            }
            else if (userInput == "7")
            {
                var studentDisplay = new StudentDisplay();
                studentDisplay.DisplayAllForeignOrPhdStudents("P");

            }
            else if (userInput == "8")
            {
                ExitApplication = true;
            }

        }

        
    }
}
