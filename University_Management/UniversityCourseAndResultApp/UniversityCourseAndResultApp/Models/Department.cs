using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace UniversityCourseAndResultApp.Models
{
    public class Department
    {
        public int Id { get; set; }
        [Required(ErrorMessage="Please Provide Depatment Code")]
        [StringLength(7,MinimumLength=2)]
        public string Code { get; set; }
        [Required(ErrorMessage = "Please Provide Depatment Name")]
        public string Name { get; set; }
    }
}