using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UniversityCourseAndResultApp.Models
{
    public class EnrollCourse
    {
        public int E_Id { get; set; }
        [Required]
        [DisplayName("Student Reg No")]
        public string StudentRegNo { get; set; }
        //[Required]
        public string Name { get; set; }
        public string StudentName { get; set; }
        public string Email { get; set; }
        public int DepartmentId { get; set; }
        public int DeptId { get; set; }
        public string DepartmentName { get; set; }
        [DisplayName("Select Course")]
        public int C_Id { get; set; }
        [Required]
        public DateTime Dates { get; set; }
        [DisplayName("Grade")]
        public int GradeId { get; set; }

    }
}