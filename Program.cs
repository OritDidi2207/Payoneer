using System;
using System.Collections.Generic;
using System.Xml.Linq;

namespace Payoneer
{
    public class Payoneer
    {
        public static void Main(string[] args)
        {
            //Q1
            //Provide a method that gets this array as an input and the output should be the maximum revenue.
            Console.WriteLine("Put the zise of slot");
            int N = int.Parse(Console.ReadLine());
            calculateStock(N);
            
            
            //Q2
            //1. Build a list of all courses that student has (StudentCourse)
            var items = new List<StudentCourseGrade>()
            {
                new StudentCourseGrade(){StudentId = 1,CourseId=1123,Grade = 34},
                new StudentCourseGrade(){StudentId = 2,CourseId=1123,Grade = 65},
                new StudentCourseGrade(){StudentId = 1,CourseId=1124,Grade = 88},            
            };
            ListOfCoursesPerStudent(items);
            
            //2. Build list of avarge course grade per course
            var items2 = new List<StudentCourseGrade>()
            {
                new StudentCourseGrade(){StudentId = 1,CourseId=1123,Grade = 34},
                new StudentCourseGrade(){StudentId = 2,CourseId=1123,Grade = 65},
                new StudentCourseGrade(){StudentId = 1,CourseId=1124,Grade = 88},
            };
            EVGperCours(items2);

        }
        //Q1
        public static void calculateStock(int size)
        {
            //A function that receives the values ​​of the stock
            int[] arr = new int[size];
            for (int i = 0; i < size; i++)
            {
                Console.WriteLine("Put the price of the stock between: " + i + ":00, to: " + (i + 1) + ":00");
                var tempNumber = Console.ReadLine();
                arr[i] = Convert.ToInt32(tempNumber);
            }

            int start = 0;
            int end = 0;
            int revenue = 0;

            //Scanning the array, and finding the maximum reveniu
            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = i + 1; j < arr.Length; j++)
                {
                    int currentRevenue = arr[j] - arr[i];
                    //Console.WriteLine("start = " + arr[i] + " end = " + arr[j] + " revenue = " + revenue + " current revenue = " + currentRevenue);
                    if (currentRevenue > revenue)
                    {
                        start = i;
                        end = j;
                        revenue = currentRevenue;
                        //print if the max revenue changed
                        //Console.WriteLine("revenue changed to " + currentRevenue);
                    }
                }
            }
            Console.WriteLine("The best hours is between" + start + ":00, to: " + end + ":00,\nthe buying price is: " + arr[start] + "$, the sale price is: " + arr[end] +
            "$\nso the max revenue is: " + revenue + "$");
        }
        
        //Q2
        //1. Build a list of all courses that student has (StudentCourse)
        public static void ListOfCoursesPerStudent(List<StudentCourseGrade> list)
        {
            var newList = new List<StudentCourse>();
            for(int i = 0; i < list.Count; i++)
            {
                //Save the handle student, And scan all the courses for this student
                int currentID = list[i].StudentId;
                //Array for the courses
                var listOfCorses = new List<int>();
                //Add the first 1
                listOfCorses.Add(list[i].CourseId);

                for (int j=i+1; j<list.Count; j++)
                {                    
                    if (currentID == list[j].StudentId) //If we found course for this student
                    {
                        listOfCorses.Add(list[j].CourseId);//add it to the list of courses
                        list.Remove(list[j]);// and remove this item from the list(so we will not scan it again                     
                        j--;   //because of the removing                     
                    }
                }
                newList.Add(new StudentCourse { studentId = currentID, Courses = listOfCorses });// add the student to StudentCourse with ID, and List of courses

            }
            foreach (var item in newList.OrderBy(student => student.studentId)) Console.WriteLine(item);//Print the List

        }

        //2. Build list of avarge course grade per course
        public static void EVGperCours(List<StudentCourseGrade> list)
        { 
            //Dictionary<CourseID,Grade>
            var listOfEVGCourses = new Dictionary<int, int>() ;
            //Scan the list and calculate the avarage of the grade for each course
            for (int i = 0; i < list.Count; i++)
            {
                int sum = list[i].Grade;
                int count = 1;
                int currentCours = list[i].CourseId;
                for(int j =i+1; j<list.Count; j++)
                {
                    if(currentCours == list[j].CourseId)
                    {
                        count++;
                        sum = sum + list[j].Grade;
                        list.Remove(list[j]);
                        j--;
                    }
                }
                listOfEVGCourses.Add(key: currentCours, value: (sum / count));
            }

            foreach (var p in listOfEVGCourses)
            {
                Console.WriteLine("\n");
                Console.Write("Course id =" +(p.Key));
                Console.Write("Everage is: "+(p.Value));
               
            }
        }
    }
}