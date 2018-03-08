using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityCourseAndResultApp.University.Core.BLL;
using UniversityCourseAndResultApp.Models;

namespace UniversityCourseAndResultApp.Controllers
{
    public class TeacherController : Controller
    {
        TeacherManager aManager = new TeacherManager();

        public ActionResult SaveTeacher()
        {
            
            ViewBag.getDesignation = GetAllDesignation();
            
            ViewBag.Departments = GetAllDiparment();

            return View();
        }

        public ActionResult AssignToTeacher()
        {
            ViewBag.department = aManager.GetAllDepartmentList();
            ViewBag.teacher = aManager.GetAllTeacherList();
            ViewBag.course = aManager.ShowAllCourse();
            return View();
        }

        [HttpPost]
        public ActionResult SaveTeacher(Teacher aTeacher)
        {

            
            ViewBag.getDesignation = GetAllDesignation();

            ViewBag.Departments = GetAllDiparment();

            if (aTeacher.Credit > 0)
            {
                Teacher cheakEmail = aManager.IfEmailExits(aTeacher);
                if (cheakEmail == null)
                {

                    int roweffected = aManager.SaveTeacher(aTeacher);
                    if (roweffected > 0)
                    {
                        ViewBag.message = "Save Sucessfully";
                    }
                    else
                    {
                        ViewBag.message = "Save Failed!";
                    }
                }
                else
                {
                    ViewBag.message = "Email Id Already Exits!";
                }
            }
            else
            {
                ViewBag.message = "Credict Can't be a Negative!";
            }
            
            return View();
        }

      

        [HttpPost]
        public ActionResult AssignToTeacher(Teacher aTeacher)
        {
            ViewBag.department = aManager.GetAllDepartmentList();
            ViewBag.teacher = aManager.GetAllTeacherList();
            ViewBag.course = aManager.ShowAllCourse();
            return View();
        }

        public JsonResult GetTeacherByDepartmentId(int Ids)
        {
            var Teacher = aManager.GetAllTeacherList();
            var TeacherList = Teacher.Where(a => a.DepartmentId == Ids).ToList();
            //var DepartmentCode = aManager.GetAllDepartmentList();
            //var CodeList = DepartmentCode.Where(a => a.Id == Ids).ToList();
            return Json(TeacherList, JsonRequestBehavior.AllowGet);
        }

        //public JsonResult GetCourseCode(int Ids)
        //{
        //    var DepartmentCode = aManager.GetAllDepartmentList();
        //    var CodeList = DepartmentCode.Where(a => a.Id == Ids).ToList();
        //    return Json(CodeList, JsonRequestBehavior.AllowGet);
        //}
        public JsonResult GetCourseCredit(int Ids)
        {
            var Credit = aManager.GetAllTeacherList();
            var CreditList = Credit.Where(a => a.T_Id == Ids).ToList();
            return Json(CreditList, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetCourseCode(int Ids)
        {
            var courseCode = aManager.ShowAllCourse();
            var courseList = courseCode.Where(a => a.DepartmentId == Ids).ToList();
            return Json(courseList, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetCourseName(int Ids)
        {
            var Name = aManager.ShowAllCourse();
            var nameList = Name.Where(a => a.DepartmentId == Ids).ToList();
            return Json(nameList, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetCredit(int Ids)
        {
            var Name = aManager.ShowAllCourse();
            var nameList = Name.Where(a => a.DepartmentId == Ids).ToList();
            return Json(nameList, JsonRequestBehavior.AllowGet);
        }

        private List<SelectListItem> GetAllDesignation()
        {
            List<Designation> aDesignations = aManager.GetAllDesignat();
            List<SelectListItem>selectList=new List<SelectListItem>();
            selectList.Add(new SelectListItem{Value = "",Text = "---------Select---------"});
            foreach (Designation desi in aDesignations)
            {
                selectList.Add(new SelectListItem{Value =desi.Id.ToString(),Text = desi.DesinationName});
            }
            return selectList;
        }
        private List<SelectListItem> GetAllDiparment()
        {
            List<Department> aDepartment = aManager.GetAllDepartmentList();
            List<SelectListItem> selectList = new List<SelectListItem>();
            selectList.Add(new SelectListItem { Value = "", Text = "-------Select--------" });
            foreach (Department dept in aDepartment)
            {
                selectList.Add(new SelectListItem { Value = dept.Id.ToString(), Text = dept.Name });
            }
            return selectList;
        }
	}
}