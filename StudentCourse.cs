using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Payoneer
{
    class StudentCourse
    {
        public int studentId { get; set; }
        public List<int> Courses { get; set; }
        public override string ToString()
        {
            StringBuilder strBuilder = new StringBuilder();
            foreach (var item in Courses)
            {
                strBuilder.Append(item.ToString());
                strBuilder.Append(", ");
            }

            return "Student ID:" + studentId + "\ncurses "+ strBuilder.ToString();
        }
    }
}
