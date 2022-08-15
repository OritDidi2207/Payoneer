using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payoneer
{
    public class StudentCourseGrade
    {
        public int StudentId { get; set; }
        public int CourseId { get; set; }
        public int Grade { get; set; }


        public StudentCourseGrade()
        {
        }
        public override string ToString()
        {
            return "Student ID:" + StudentId + "\nCourse ID " + CourseId +"\nGrade: "+Grade;
        }

    }
}
