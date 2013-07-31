using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace University
{
    public class Student
    {
        public string Name { get; set; }
        public List<Course> Courses = new List<Course>();
        public Dictionary<Course, double> Grades = new Dictionary<Course, double>();
        public double GPA
        {
            get
            {
                double gpa = 0.0;
                foreach (Course c in Courses)
                {
                    Course _course = c;
                    gpa += GetGradeByCourse(ref _course);
                }
                return gpa / Courses.Count;
            }
            set
            {
                GPA = value;
            }
        }

        public Student(string name)
        {
            Name = name;
        }

        public void AddCourse(ref Course course)
        {
            this.Courses.Add(course);
        }

        public double GetGradeByCourse(ref Course course)
        {
            double grade = 0.0;
            this.Grades.TryGetValue(course, out grade);
            return grade;
        }

        public void SetGradeByCourse(ref Course course, double grade)
        {
            this.Grades.Add(course, grade);
        }

        public string GetObjectParentName()
        {
            return this.ToString();
        }
    }

    public class StudentList
    {
        public List<Student> Students = new List<Student>();
        public StudentList()
        {
            this.Students = GetStudentList();
        }
        private List<Student> GetStudentList()
        {
            List<Student> students = new List<Student>();
            Student s;
            s = new Student("Student One");
            students.Add(s);
            s = new Student("Student Two");
            students.Add(s);
            s = new Student("Student Three");
            students.Add(s);
            //s = new Student("Student Four");
            //students.Add(s);
            return students;
        }
        public Student GetStudentByName(string name)
        {
            Student student = new Student("Null");
            foreach (Student s in this.Students)
            {
                if (s.Name == name)
                    student = s;
            }
            return student;
        }
    }
}