using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentGradeTrackingSystem
{
    internal class Student
    {
        public int ID { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public int Midterm { get; set; }
        public int Final {  get; set; }
    }
}
