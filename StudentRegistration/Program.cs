using CommonComponents;
using System;

namespace StudentRegistration
{
    class Program
    {
        static void Main(string[] args)
        {
            //Seperated the class I only wanted the main method to get the user input
            //Displaying the options is left to other classes.
            var UserSelection = new UserSelection();

            while (UserSelection.ExitApplication == false)
            {
                //Display the list to the user and what options they have to pick from
                UserSelection.DisplayUserOptions();

                //Get the users input and display/run the method required.
                var userInput = Console.ReadLine();


                //Validate the user input on the selection screen is between 1-8 and is numeric
                if (Validation.InvalidInputCheck(userInput) == false)
                {

                    Console.WriteLine(Validation.errorMessage);
                }
                else
                {

                    Console.Clear();
                    UserSelection.UsersInput(userInput);

                }


            }


        }
    }
}
