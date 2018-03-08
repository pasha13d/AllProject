using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityCourseAndResultApp.Models;
using UniversityCourseAndResultApp.University.Core.BLL;
namespace UniversityCourseAndResultApp.Controllers
{
    public class DepartmentController : Controller
    {

        DepartmentManager aManager = new DepartmentManager();
        public ActionResult SaveDepartment( )
        {
            return View();
        }
        [HttpPost]
        public ActionResult SaveDepartment(Department aDepartment)
        {
            if (aDepartment.Code.Length >= 2 && aDepartment.Code.Length <= 7)
            {
                Department deptCode = aManager.ifCodeExit(aDepartment);
                Department deptName = aManager.ifNameExit(aDepartment);

                if (deptCode == null && deptName == null)
                {
                    int roweffected = aManager.SaveDepartment(aDepartment);
                    if (roweffected > 0)
                    {
                        ViewBag.mess = "Save Sucessfully";
                    }
                    else
                    {
                        ViewBag.message = "Department Save Failed!";
                    }
                }
                else
                {
                    ViewBag.message = "Code or Department Name are Already Exits!";
                }
            }
            else
            {
                ViewBag.message = "Code Must Be 2-7 Character";
            }
            return View();
        }

        public ActionResult ShowAllDepartment(Department aDepartment)
        {
           var department= aManager.ShowAllDepartments(aDepartment);
            return View(department);
        }

       
	}
}