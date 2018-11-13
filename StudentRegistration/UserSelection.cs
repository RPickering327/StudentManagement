using System;
using static CommonComponents.Validation;
using static System.Console;

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


        public void DisplayUserOptions()
        {
            //Displays the list of options to the user. Clears it at first to ensure all other text is kept
            // of the screen and not in the users face.
            errorMessage = "";
            WriteLine("Please select an option between 1-6");
            WriteLine("1. Add a new student to the database");
            WriteLine("2. Add a student to a course");
            WriteLine("3. Add a course");
            WriteLine("4. Update grades");
            WriteLine("5. View all students on each course");
            WriteLine("6. List all foreign students");
            WriteLine("7. List all PHD students");
            WriteLine("8. Exit Application");

        }


        public void UsersInput(string userInput)
        {
            //Takes the user input from the console and then proceeds to action what they want to do.
            if (userInput == "1")
            {
                WriteLine("Please enter the students first name");
                var firstName = Console.ReadLine();

                WriteLine("Please enter the students last name");
                var lastName = Console.ReadLine();

                WriteLine("Please enter the students address");
                var address = Console.ReadLine();

                WriteLine("Please enter the student student type");
                WriteLine("U = Undergraduate, P = Postgraduate, F = Foreign student");
                var studentType = Console.ReadLine();

                var newStudent = new StudentRepository();
                newStudent.AddStudent(firstName, lastName, address, studentType);

            }
            else if (userInput == "2")
            {

                WriteLine("Please enter the course ID");
                var courseID = Console.ReadLine();

                WriteLine("Please enter the student ID");
                var studentID = Console.ReadLine();

                var newCourse = new CourseRepository();
                newCourse.CheckGrade(int.Parse(courseID), int.Parse(studentID));
                newCourse.AddStudentToCourse(int.Parse(studentID), int.Parse(courseID));

            }
            else if (userInput == "3")
            {

                WriteLine("Please enter the coursename");
                var courseName = Console.ReadLine();

                WriteLine("Please enter the minimum percentage grade 1-100");
                var minimumGrade = Console.ReadLine();

                var newCourse = new CourseRepository();

                newCourse.AddNewCourse(courseName, int.Parse(minimumGrade));

            }
            else if (userInput == "4")
            {

                WriteLine("Please enter the student ID");
                var studentId = Console.ReadLine();

                WriteLine("Please enter thier grade");
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
