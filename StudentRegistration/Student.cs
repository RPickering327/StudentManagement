using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentRegistration
{
   public class Student
    {
        public Student()
        {

        }

        public Student(int studentId)
        {
            this.StudentId = StudentId;
        }

        public int StudentId { get; private set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public char StudentType { get; set; }

    }
}
