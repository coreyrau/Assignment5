using Assignment5;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment5BusinessLayer
{
    public interface IBusinessLayer
    {
        //Teacher
        IList<Teacher> GetAllTeachers();
        Teacher GetTeacherByID(int id);
        Teacher GetTeacherByName(string name);
        void AddTeacher(Teacher teacher);
        void UpdateTeacher(Teacher student);
        void RemoveTeacher(Teacher student);

        //Course
        IList<Course> GetAllCourses();
        Course GetCourseByID(int id);
        Course GetCourseByName(string name);
        void AddCourse(Course couse);
        void UpdateCourse(Course course);
        void RemoveCourse(Course course);

        void AddCourseToTeacher(int teacherid, int courseid);
    }
}
