using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace UniversityCourseAndResultApp.Models
{
    public class Teacher
    {
        public int T_Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        [Required (ErrorMessage="Please Provide Your Email")]
        [RegularExpression(@"[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,4}", ErrorMessage = "Please enter correct email")]
        public string Email { get; set; }
        public string ContactNo { get; set; }
        [DisplayName("Degination")]
        public int DeginationId { get; set; }
        [DisplayName("Department")]
        public int DepartmentId { get; set; }
        [DisplayName("Credit to be Taken")]
        public Decimal Credit { get; set; }
    }
}