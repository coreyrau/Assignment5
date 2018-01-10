using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assignment5;

namespace Assignment5BusinessLayer
{
    public class BusinessLayer : IBusinessLayer
    {
        private readonly TeacherRepository _TeacherRpository;
        private readonly CourseRepository _CourseRepository;

        public BusinessLayer()
        {
            _TeacherRpository = new TeacherRepository();
            _CourseRepository = new CourseRepository();
        }

        public void AddCourse(Course course)
        {
            _CourseRepository.Insert(course);
        }

        public void AddCourseToTeacher(int teacherid, int courseid)
        {
            throw new NotImplementedException();
        }

        public void AddTeacher(Teacher teacher)
        {
            _TeacherRpository.Insert(teacher);
        }

        public IList<Course> GetAllCourses()
        {
            return _CourseRepository.GetAll().ToList();
        }

        public IList<Teacher> GetAllTeachers()
        {
            return _TeacherRpository.GetAll().ToList();
        }

        public Course GetCourseByID(int id)
        {
            return _CourseRepository.GetById(id);
        }

        public Course GetCourseByName(string name)
        {
            return _CourseRepository.GetSingle(
                c => c.CourseName.Equals(name),
                c => c.CourseId,
                c => c.Teacher);
        }

        public Teacher GetTeacherByID(int id)
        {
            return _TeacherRpository.GetById(id);
        }

        public Teacher GetTeacherByName(string name)
        {
            return _TeacherRpository.GetSingle(
                t => t.TeacherName.Equals(name),
                t => t.TeacherId,
                t => t.Courses
                );
        }

        public void RemoveCourse(Course course)
        {
            _CourseRepository.Delete(course);
        }

        public void RemoveTeacher(Teacher teacher)
        {
            _TeacherRpository.Delete(teacher);
        }

        public void UpdateCourse(Course course)
        {
            _CourseRepository.Update(course);
        }

        public void UpdateTeacher(Teacher teacher)
        {
            _TeacherRpository.Update(teacher);
        }
    }
}
