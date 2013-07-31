using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace University
{
    public class Course
    {
        public string Name { get; set; }
        public string Number { get; set; }
        public int Tuition { get; set; }
        double Grade { get; set; }
        public List<Student> Students = new List<Student>();

        public Course(string name, string number, int tuition)
        {
            Name = name;
            Number = number;
            Tuition = tuition;
        }

        public void AddStudent(ref Student s)
        {
            this.Students.Add(s);
        }

    }

    public class CourseList
    {
        public List<Course> Courses = new List<Course>();
        public CourseList()
        {
            this.Courses = GetCourseList();
        }
        private List<Course> GetCourseList()
        {
            List<Course> courses = new List<Course>();
            Course c;
            c = new Course("Computer Science 1", "CS100", 1025);
            courses.Add(c);
            c = new Course("Computer Science 2", "CS200", 1250);
            courses.Add(c);
            c = new Course("Computer Science 3", "CS300", 1475);
            courses.Add(c);
            c = new Course("Computer Science 4", "CS400", 1700);
            courses.Add(c);
            c = new Course("Computer Science 5", "CS500", 1925);
            courses.Add(c);
            c = new Course("Computer Science 6", "CS600", 2150);
            courses.Add(c);
            c = new Course("Computer Science 7", "CS700", 2325);
            courses.Add(c);
            c = new Course("Computer Science 8", "CS800", 2550);
            courses.Add(c);
            return courses;
        }
        public Course GetCourseByNumber(string number)
        {
            Course course = new Course("Null", "Null", 0);
            foreach (Course c in this.Courses)
            {
                if (c.Number == number)
                    course = c;
            }
            return course;
        }
    }
}