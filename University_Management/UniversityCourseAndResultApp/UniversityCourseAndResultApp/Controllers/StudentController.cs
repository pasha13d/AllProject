using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityCourseAndResultApp.Models;
using UniversityCourseAndResultApp.University.Core.BLL;


namespace UniversityCourseAndResultApp.Controllers
{
    public class StudentController : Controller
    {
        StudentManager aManager = new StudentManager();
        EnrollManager anEnrollManager = new EnrollManager();
        EnrollCourse aCorse = new EnrollCourse();
        public ActionResult SaveStudentData()
        {

            List<Department> aDepartment = aManager.ShowAllDepartment();
            ViewBag.Department = aDepartment;

            var student = aManager.ShowAllStudent();
            return View();
        }
        public ActionResult EnrolCourse()
        {
            List<Student> aStudent = aManager.ShowAllStudent();
            ViewBag.student = aStudent;
            return View();
        }

        public ActionResult StudentResult()
        {
            List<Student> aStudent = aManager.ShowAllStudent();
            ViewBag.student = aStudent;

            List<Grade> aGrade = aManager.GetAllGrade();
            ViewBag.grade = aGrade;
            return View();
        }
        
        [HttpPost]
        public ActionResult SaveStudentData(Student aStudent)
        {
            Department department = aManager.ShowAllDepartment().Find(c => c.Id == aStudent.DeptId);
            string deptName = department.Code;
            var studenCount = aManager.ShowAllStudent().Where(c => c.DeptId == aStudent.DeptId & c.BirthDate.Year == aStudent.BirthDate.Year);
            int count = studenCount.Count() + 1;
            string Regnos = deptName + "-" + aStudent.BirthDate.Year + "-" + count;
            List<Department> aDepartment = aManager.ShowAllDepartment();
            ViewBag.Department = aDepartment;

            if (ModelState.IsValid)
            {
                
            
            Student StudentEmail = aManager.IfEmailExits(aStudent);
            if (StudentEmail == null)
            {

                int roweffected = aManager.SaveStudent(aStudent, Regnos);

                if (roweffected > 0)
                {
                    ViewBag.mess = "Register Successfully...And your Registration Number :" + Regnos+ " "+"Name :"+aStudent.Name+" "+" "+"Email:"+aStudent.Email;
                    ViewBag.save = aManager.SaveStudent(aStudent, Regnos);
                    //return RedirectToAction("ShowAllStudent");
                }
                else
                {
                    ViewBag.message = "Register Failed!";
                }
            }
            else
            {
                ViewBag.message = "Email Id Already Exits!";
            }
           }
            
            return View();
        }

        [HttpPost]
        public ActionResult EnrolCourse(EnrollCourse aCourse)
        {
            List<Student> aStudent = aManager.ShowAllStudent();
            ViewBag.student = aStudent;

            //if (ModelState.IsValid)
            //{
                int roweffected = anEnrollManager.EnrollStudent(aCourse);
               
                if (roweffected > 0)
                {
                    ViewBag.message = "Enroll Student";
                }
                else
                {
                    ViewBag.message = "Enroll Failed!";
                }
            //}
            return View();
            
        }
        [HttpPost]
        public ActionResult StudentResult(EnrollCourse aEnroll)
        {
            List<Student> aStudent = aManager.ShowAllStudent();
            ViewBag.student = aStudent;

            List<Grade> aGrade = aManager.GetAllGrade();
            ViewBag.grade = aGrade;

            int roweffected = anEnrollManager.ResultStudent(aEnroll);

            if (roweffected>0)
            {
                ViewBag.message = "Save Sucessfully";
            }
            else
            {
                ViewBag.message = "Faild!";
            }
            return View();
        }
        public ActionResult ShowAllStudent()
        {
            var student = aManager.ShowAllStudent();
            return View(student);
        }
      
        public JsonResult GetStudentName(int Ids)
        {

            var name = aManager.ShowAllStudent();
            var nameList = name.Where(a => a.Id == Ids).ToList();
            return Json(nameList, JsonRequestBehavior.AllowGet);
        }
       
        public JsonResult GetStudentEmail(int Ids)
        {
            var Email = aManager.ShowAllStudent();
            var EmailList = Email.Where(a => a.Id == Ids).ToList();
            return Json(EmailList, JsonRequestBehavior.AllowGet);
        }
    
        public JsonResult GetStudentDept(int Ids)
        {
            var dept = aManager.StudentDepartment();
            var deptList = dept.Where(a => a.E_Id == Ids).ToList();
            return Json(deptList, JsonRequestBehavior.AllowGet);
        }
  
        public JsonResult GetSelectCourse(int Ids)
        {
            var course = aManager.GetAllCourse();
            var courseList = course.Where(a => a.Id == Ids).ToList();
            return Json(courseList, JsonRequestBehavior.AllowGet);
        }
        
    }
}