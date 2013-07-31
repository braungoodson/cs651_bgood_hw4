/**
 * So basically what I did here was maybe more than I had to or whatever
 * but in either case it was good practice to define these classes as I 
 * did.. Plus it looks pretty neat ;]
 * 
 * Hopefully the way I did them is what you were expecting and/or
 * acceptable.
 * __
 * + University.cs
 *    - Contains Manager that creates a fake university with students, 
 *       and courses
 *    - Tried to make it as efficient as possible using refs
 * __
 * + University.Course.css
 *    - Contains Course class and CourseList class
 *    - Basically made the course list static, but not explicitly? or 
 *       something to that nature
 *    - Was going to add some sort of delegate to allow automatic 
 *       addition of student to course list when student added course, 
 *       but didn't have time (or at least this is how I imagine it
 *       could have worked)
 * __ 
 * + University.Student.cs
 *    - Essentially same concept here at with the course class
 *    - Plus a bunch of neat methods to work with the object
 *  
 * A+! ;] X]
 * 
 * It'd be nice to get any sort of feedback on how I'm understanding 
 * C# IF I am at all (in respect to how I approached the assignment, 
 * did I achieve efficiency? If so, what level (i.e., jedi, average, 
 * rookie, ect.)..
 * 
 * */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using University;

namespace HW4_GOODSON
{
    class Program
    {
        static void LINQQuery001(ref UniversityManager u)
        {
            //LINQ Query 1
            var linq1 =
                from student in u.StudentList_.Students
                select new
                {
                    Name = student.Name,
                    Courses =
                        student.Courses.Aggregate(
                            new StringBuilder(),
                            (sb, i) => sb.Append(i.Name.ToString()).Append("\n\t "),
                            sp => sp.ToString()
                        )
                };

            foreach (var s in linq1)
                Console.WriteLine("Student: {0}\nCourses: {1}", s.Name, s.Courses);

            Console.WriteLine("Press any key for next LINQ query...");
            Console.ReadLine();
            Console.Clear();
        }

        static void LINQQuery002(ref UniversityManager u)
        {
            //LINQ Query 2
            var linq2 =
                from student in u.StudentList_.Students
                where student.GPA > 3.0
                select new { Name = student.Name.ToString() };

            String sg = linq2.Aggregate(
                new StringBuilder(),
                (sb, i) => sb.Append(i.Name).Append("\n\t"),
                sp => sp.ToString()
            );

            Console.WriteLine("Students whose GPA > 3:\n\n\t{0}", sg);

            Console.WriteLine("Press any key for next LINQ query...");
            Console.ReadLine();
            Console.Clear();
        }

        static void LINQQuery003(ref UniversityManager u)
        {
            //LINQ Query 3
            var linq3 =
                from course in u.CourseList_.Courses
                select new
                {
                    Name = course.Name,
                    Students =
                        course.Students.Aggregate(
                            new StringBuilder(),
                            (sb, i) => sb.Append(i.Name.ToString()).Append("\n\t  "),
                            sp => sp.ToString()
                        )
                };

            foreach (var c in linq3)
                Console.WriteLine("Course: {0}\nStudents: {1}", c.Name, c.Students);

            Console.WriteLine("Press any key for XML...");
            Console.ReadLine();
            Console.Clear();
        }

        static XElement CreateXMLDocument(ref UniversityManager u)
        {
            XElement root = new XElement("Students");
            foreach (Student s in u.StudentList_.Students)
            {
                XElement se = new XElement("Student",
                    new XAttribute("Name", s.Name),
                    new XAttribute("GPA", s.GPA)
                );
                foreach (Course c in s.Courses)
                {
                    Course _course = c;
                    double grade = s.GetGradeByCourse(ref _course);
                    XElement ce = new XElement("Course",
                        new XAttribute("Name", c.Name),
                        new XAttribute("Number", c.Number),
                        new XAttribute("Tuition", c.Tuition),
                        // for some reason round isn't working...
                        new XAttribute("Grade", Math.Round(grade,3))
                    );
                    se.Add(ce);
                }
                root.Add(se);
            }

            Console.WriteLine(root);
            Console.WriteLine("Press any key for total tution...");
            Console.ReadLine();
            Console.Clear();

            return root;
        }

        static void LINQQuery004(ref XElement r)
        {
            int s = 0;
            var linq4 =
                from e in r.Elements("Student").Elements("Course")
                let t = (int)e.Attribute("Tuition")
                select new { Bank = t };

            //hopefuly this is right, i couldn't find any IntBuilder type methods...
            foreach (var t in linq4)
                s += t.Bank;

            Console.WriteLine("Total tuition collected: {0}", s);

        }

        static void Main(string[] args)
        {
            UniversityManager u = new UniversityManager();
            u.SimulateUniversity();
            //Test001(ref u);

            LINQQuery001(ref u);
            LINQQuery002(ref u);
            LINQQuery003(ref u);
            XElement r = CreateXMLDocument(ref u);
            LINQQuery004(ref r);
        }

        static void Test001(ref UniversityManager u)
        {
            foreach (Student s in u.StudentList_.Students)
                foreach (Course c in s.Courses)
                    Console.WriteLine("{0} is taking {1}", s.Name, c.Name);

            Console.WriteLine("A Student GPA is {0}", u.StudentList_.GetStudentByName("Student One").GPA.ToString());
        }
    }
}
