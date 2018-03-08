using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UniversityCourseAndResultApp.Models
{
    public class AllocateClassroom
    {
        public int AllocateClassroomId { get; set; }
        public int DepartmentId { get; set; }
        public string CourseName { get; set; }
        public string RoomNo { get; set; }
        public string Day { get; set; }
        [DataType(DataType.Time)]
        public TimeSpan From { get; set; }

        [DataType(DataType.Time)]
        public TimeSpan To { get; set; }
       
    }
}