using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityCourseAndResultApp.Models;
using UniversityCourseAndResultApp.University.Core.DAL;

namespace UniversityCourseAndResultApp.University.Core.BLL
{
    public class StudentManager
    {
        StudentGatway aGatway = new StudentGatway();

        public int SaveStudent(Student aStudent, string Regnos)
        {
            return aGatway.SaveStudent(aStudent, Regnos);
        }
        public List<Department> ShowAllDepartment()
        {
            return aGatway.ShowAllDepartment();
        }

        public List<Student> ShowAllStudent()
        {
            return aGatway.ShowAllStudent();
        }

        public Student IfEmailExits(Student aStudent)
        {
            return aGatway.IfEmailExits(aStudent);
        }

        public List<EnrollCourse> StudentDepartment()
        {
            return aGatway.StudentDepartment();
        }
        public List<CourseStudent> GetAllCourse()
        {
            return aGatway.GetAllCourse();
        }
        public List<Grade> GetAllGrade()
        {
            return aGatway.GetAllGrade();
        }
    }
}