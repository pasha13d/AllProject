using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UniversityCourseAndResultApp.Models
{
    public class CourseStudent
    {

        public int Id { get; set; }
        public string CourseName { get; set; }
        public string RegNo { get; set; }
        public int DeptId { get; set; }
    }
}