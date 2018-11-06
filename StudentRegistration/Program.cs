using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonComponents;

namespace StudentRegistration
{
    class Program
    {
        static void Main(string[] args)
        {
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
                else {

                    Console.Clear();
                    UserSelection.UsersInput(userInput);

                }


            }


        }
    }
}
