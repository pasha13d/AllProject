using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityCourseAndResultApp.Models;
using UniversityCourseAndResultApp.University.Core.DAL;

namespace UniversityCourseAndResultApp.University.Core.BLL
{
    public class DepartmentManager
    {
        DepartmentGatway aDepartmentGatway = new DepartmentGatway();

        public Department ifCodeExit(Department aDepartmentCode)
        {
            return aDepartmentGatway.IfCodeExit(aDepartmentCode);
        }

        public Department ifNameExit(Department aDepartmentName)
        {
            return aDepartmentGatway.ifNameExit(aDepartmentName);
        }

        public int SaveDepartment(Department aDepartment)
        {
            return aDepartmentGatway.SaveDepartment(aDepartment);
        }

        public List<Department>ShowAllDepartments(Department aDepartment)
        {
            return aDepartmentGatway.ShowAllDepartments(aDepartment);
        }
    }
}