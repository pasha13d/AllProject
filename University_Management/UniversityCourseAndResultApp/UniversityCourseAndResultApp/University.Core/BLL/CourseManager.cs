using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityCourseAndResultApp.Models;
using UniversityCourseAndResultApp.University.Core.DAL;

namespace UniversityCourseAndResultApp.University.Core.BLL
{
    public class CourseManager
    {
        CourseGatway aCourseGatway = new CourseGatway();

        public int SaveCourse(Course aCourse)
        {
            return aCourseGatway.SaveCourse(aCourse);
        }
        public List<Semester> GetAllSemester()
        {
            return aCourseGatway.GetAllSemester();
        }

        public List<Department> GetAllDepartmentList()
        {
            return aCourseGatway.GetAllDepartmentList();
        }

        public Course IfCodeExit(Course aCourse)
        {
            return aCourseGatway.IfCodeExit(aCourse);
        }

        public Course IfNameExit(Course aCourse)
        {
            return aCourseGatway.IfNameExit(aCourse);
        }

       
    }
}