using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace UniversityCourseAndResultApp.Models
{
    public class Student
    {
        public int Id { get; set; }
        [Required(ErrorMessage="Please Provide Your Name")]
        public string Name { get; set; }
        [Required(ErrorMessage="Please Provide Your Email")]
        [RegularExpression(@"[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,4}", ErrorMessage = "Please enter correct email")]
        public string Email { get; set; }
        public string ContactNo { get; set; }
        [DisplayName("Date of Birth")]
        [Display(Name = "Date")]
        public DateTime BirthDate { get; set; }
        public string Address { get; set; }
        
        //public int DepartmentId { get; set; }
        [DisplayName("Department")]
        public int DeptId { get; set; }
        public string RegNo { get; set; }
    }
}