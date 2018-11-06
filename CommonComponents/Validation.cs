using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CommonComponents
{
    public static class Validation
    {
        //Error meessage to be displayed if the validation variable is set to false.
        public static string errorMessage = "";

        //By default validation is believe to be true if any of them fail it will be set to false blocking the methods from executing.
        public static bool ValidationSuccessfully = true;


        //For the console application ensure the first input is set to a number between 1 - 8
        public static bool InvalidInputCheck(string userInput) {

            int x;
            ValidationSuccessfully = int.TryParse(userInput, out x);

            if (ValidationSuccessfully)
            {
                if (x <= 1 && x > 8)
                {
                    errorMessage = "Please only select a number between 1-8";
                }
            }
            else
            {

                errorMessage = "You've entered a non numeric input";
            }

            return ValidationSuccessfully;
        }


        //Verify the name is not null
        public static bool ValidNameCheck(string input) {

            if (string.IsNullOrWhiteSpace(input))
            {
                ValidationSuccessfully = false;
                errorMessage += "Names cannot be empty" + "\n" ;
            }

          if (!(Regex.IsMatch(input, @"^[a-zA-Z]+$")))
            {
                ValidationSuccessfully = false;
                errorMessage += "Names can only have letters. Numbers & special characters are not allowed. " + "\n";
            }

            return ValidationSuccessfully;

        }
        
      
        //Verify that only U, P or F is entered into the database
        public static bool ValidStudentType(string input) {

            input.ToUpper();

            if (!(input.Contains("U") || input.Contains("P") || input.Contains("F")))
            {
                ValidationSuccessfully = false;
                errorMessage += "You've entered the wrong student type it can only be U, P or F" + "\n";

            }
         

            return ValidationSuccessfully;

        }
    }
  }