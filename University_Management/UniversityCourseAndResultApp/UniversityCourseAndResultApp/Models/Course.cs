using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace UniversityCourseAndResultApp.Models
{
    public class Course
    {
        public int C_Id { get; set; }
        [StringLength(10,MinimumLength=5)]
        public string Code { get; set; }
        public string RegNo { get; set; }
        public string Name { get; set; }
        public decimal Credit { get; set; }
        public string Description { get; set; }
        [DisplayName("Department Name")]
        public int DepartmentId { get; set; }
        [DisplayName("Semester Name")]
        public int SemesterId { get; set; }
        public DateTime Dates { get; set; }
    }
}