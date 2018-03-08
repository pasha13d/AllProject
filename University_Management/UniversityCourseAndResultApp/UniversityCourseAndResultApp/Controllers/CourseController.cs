using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityCourseAndResultApp.Models;
using UniversityCourseAndResultApp.University.Core.BLL;

namespace UniversityCourseAndResultApp.Controllers
{
    public class CourseController : Controller
    {
        CourseManager aManager = new CourseManager();
       
        public ActionResult SaveCourese()
        {
            ViewBag.Department = GetAllDiparment();
            ViewBag.semester = GetallSemester();
            return View();
        }
        [HttpPost]
        public ActionResult SaveCourese(Course aCourse)
        {
            ViewBag.Department = GetAllDiparment();

            ViewBag.semester = GetallSemester();

            if (aCourse.Code.Length >= 5)
            {

                if (aCourse.Credit >= 0.5m && aCourse.Credit <= 5.0m)
                {
                    Course CourseCode = aManager.IfCodeExit(aCourse);
                    Course CourseName = aManager.IfNameExit(aCourse);


                    if (CourseCode == null && CourseName == null)
                    {
                        int roweffced = aManager.SaveCourse(aCourse);

                        if (roweffced > 0)
                        {
                            ViewBag.mess = "Save Sucessfully";
                            
                        }
                        else
                        {
                            ViewBag.message = "Data Save Failed!";
                        }

                    }
                    else
                    {
                        ViewBag.message = "Course Name or Course Code Already Exits!";
                    }
                }
                else
                {
                    ViewBag.message = "Credit Rang Must 0.5 to 5.0";
                }
            }
            else
            {
                ViewBag.message = "Code Must at Last 5 Character";
            }
            return View();
        }

        private List<SelectListItem> GetAllDiparment()
        {
            List<Department> aDepartment = aManager.GetAllDepartmentList();
            List<SelectListItem> selectList = new List<SelectListItem>();
            selectList.Add(new SelectListItem{Value = "",Text = "-------Select-----"});
            foreach (Department dept in aDepartment)
            {
                selectList.Add(new SelectListItem{Value = dept.Id.ToString(),Text = dept.Name});
            }
            return selectList;
        }

        private List<SelectListItem> GetallSemester()
        {
            List<Semester> aSemester = aManager.GetAllSemester();
            List<SelectListItem>selectList=new List<SelectListItem>();
            selectList.Add(new SelectListItem{Value = "",Text = "--------Select---------"});

            foreach (Semester Sem in aSemester)
            {
                selectList.Add(new SelectListItem{Value =Sem.SemId.ToString(),Text = Sem.Name});
            }
            return selectList;
        }
	}
}