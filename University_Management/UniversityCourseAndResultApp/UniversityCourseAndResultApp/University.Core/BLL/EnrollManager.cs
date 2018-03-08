using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityCourseAndResultApp.University.Core.DAL;
using UniversityCourseAndResultApp.Models;

namespace UniversityCourseAndResultApp.University.Core.BLL
{
    public class EnrollManager
    {
        EnrollGatway aGatway = new EnrollGatway();

        public int EnrollStudent(EnrollCourse aEnroll)
        {
            return aGatway.EnrollStudent(aEnroll);
        }

        public int ResultStudent(EnrollCourse aEnroll)
        {
            return aGatway.ResultStudent(aEnroll);
        }
    }
}