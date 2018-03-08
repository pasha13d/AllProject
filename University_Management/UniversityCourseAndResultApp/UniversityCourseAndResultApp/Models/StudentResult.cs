using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UniversityCourseAndResultApp.Models
{
    public class StudentResult
    {
        public int SRId { get; set; }
        public string RegNo { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int DepartmentId { get; set; }
        public int courseId { get; set; }
        public int GradeId { get; set; }
      
    }
}