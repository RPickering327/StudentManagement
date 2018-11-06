using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonComponents;

namespace StudentRegistration
{
   public class Student
    {
        public int StudentId { get; private set; }
        public string Address { get; set; }



        private string _firstName;
        private string _lastName;
        private string _studentType;


        public string FirstName
        {
            get { return _firstName; }
            set
            {
                Validation.ValidNameCheck(value);
                _firstName = value;
            }
        }

        public string LastName
        {
            get { return _lastName; }
            set
            {
                Validation.ValidNameCheck(value);
                _lastName = value;
            }
        }


        public string StudentType
        {
            get { return _studentType; }
            set
            {
                Validation.ValidStudentType(value);
                _studentType = value;
            }
        }


    }
}
