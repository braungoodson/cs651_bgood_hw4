using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace University
{
    public class UniversityManager
    {
        public StudentList StudentList_;
        public CourseList CourseList_;
        private Student s;
        private Course c;

        public UniversityManager()
        {
            StudentList_ = new StudentList();
            CourseList_ = new CourseList();
        }

        public void SimulateUniversity()
        {
            s = StudentList_.GetStudentByName("Student One");
            c = CourseList_.GetCourseByNumber("CS100");
            s.AddCourse(ref c);
            s.SetGradeByCourse(ref c, 4.0);
            c.AddStudent(ref s);
            c = CourseList_.GetCourseByNumber("CS200");
            s.AddCourse(ref c);
            s.SetGradeByCourse(ref c, 3.9);
            c.AddStudent(ref s);
            c = CourseList_.GetCourseByNumber("CS300");
            s.AddCourse(ref c);
            s.SetGradeByCourse(ref c, 3.2);
            c.AddStudent(ref s);
            c = CourseList_.GetCourseByNumber("CS400");
            s.AddCourse(ref c);
            s.SetGradeByCourse(ref c, 2.6);
            c.AddStudent(ref s);

            s = StudentList_.GetStudentByName("Student Two");
            c = CourseList_.GetCourseByNumber("CS100");
            s.AddCourse(ref c);
            s.SetGradeByCourse(ref c, 3.0);
            c.AddStudent(ref s);
            c = CourseList_.GetCourseByNumber("CS200");
            s.AddCourse(ref c);
            s.SetGradeByCourse(ref c, 3.9);
            c.AddStudent(ref s);
            c = CourseList_.GetCourseByNumber("CS500");
            s.AddCourse(ref c);
            s.SetGradeByCourse(ref c, 3.2);
            c.AddStudent(ref s);
            c = CourseList_.GetCourseByNumber("CS600");
            s.AddCourse(ref c);
            s.SetGradeByCourse(ref c, 3.6);
            c.AddStudent(ref s);

            s = StudentList_.GetStudentByName("Student Three");
            c = CourseList_.GetCourseByNumber("CS100");
            s.AddCourse(ref c);
            s.SetGradeByCourse(ref c, 2.0);
            c.AddStudent(ref s);
            c = CourseList_.GetCourseByNumber("CS200");
            s.AddCourse(ref c);
            s.SetGradeByCourse(ref c, 2.9);
            c.AddStudent(ref s);
            c = CourseList_.GetCourseByNumber("CS700");
            s.AddCourse(ref c);
            s.SetGradeByCourse(ref c, 3.2);
            c.AddStudent(ref s);
            c = CourseList_.GetCourseByNumber("CS800");
            s.AddCourse(ref c);
            s.SetGradeByCourse(ref c, 2.6);
            c.AddStudent(ref s);

        }
    }
}