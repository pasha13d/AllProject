using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityCourseAndResultApp.University.Core.DAL;
using UniversityCourseAndResultApp.Models;

namespace UniversityCourseAndResultApp.University.Core.BLL
{
    public class TeacherManager
    {
        TeacherGatway aTeacherGatway = new TeacherGatway();

        public int SaveTeacher(Teacher aTeacher)
        {
            return aTeacherGatway.SaveTeacher(aTeacher);
        }

        public List<Designation> GetAllDesignat()
        {
            return aTeacherGatway.GetAllDesignat();
        }
        public List<Department> GetAllDepartmentList()
        {
            return aTeacherGatway.GetAllDepartmentList();
        }
        public Teacher IfEmailExits(Teacher aTeacher)
        {
            return aTeacherGatway.IfEmailExits(aTeacher);
        }

        public List<Teacher> GetAllTeacherList()
        {
            return aTeacherGatway.GetAllTeacherList();
        }

        public List<Course> ShowAllCourse()
        {
            return aTeacherGatway.ShowAllCourse();
        }
    }
}