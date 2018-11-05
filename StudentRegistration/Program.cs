using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                UserSelection.UsersInput(userInput);

            }


        }
    }
}
