using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace StudentRegistration.Test
{
    [TestClass]
    public class StudentTests
    {
        [TestMethod]
        public void StudentFirstNameAndLastNameNull()
        {
            //Set up the instance and properties
            var student = new Student(1);
            var isValid = false;
            

        }

        [TestMethod]
        public void StudentFirstNameAndLastNameNotBlankOrNull()
        {
            //Set up the instance and properties
            var student = new Student(1);
            student.FirstName = "Richard";
            student.LastName = "Pickering";

            //Set the expected outcome of the results
            var isValid = true;


        }
    }
}
