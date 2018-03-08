using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityCourseAndResultApp.Models;
using UniversityCourseAndResultApp.University.Core.BLL;

namespace UniversityCourseAndResultApp.Controllers
{
    public class AllocateClassroomController : Controller
    {
        AllocateClassroomManager aManager = new AllocateClassroomManager();
        AllocateClassroom rooms = new AllocateClassroom();

        public ActionResult AllocateClassRoomSave()
        {
            List<Department> department = aManager.ShowAllDepartment();
            ViewBag.Department = department;

            List<Course> course = aManager.ShowAllCourse();
            ViewBag.Course = course;

            List<SevenDay> day = aManager.ShowAllDay();
            ViewBag.Days = day;

            List<Room> room = aManager.ShowAllRoom();
            ViewBag.Room = room;
            return View();
        }
        [HttpPost]
        public ActionResult AllocateClassRoomSave(AllocateClassroom aRoom)
        {
            List<Department> department = aManager.ShowAllDepartment();
            ViewBag.Department = department;

            List<Course> course = aManager.ShowAllCourse();
            ViewBag.Course = course;

            List<SevenDay> day = aManager.ShowAllDay();
            ViewBag.Days = day;

            List<Room> room = aManager.ShowAllRoom();
            ViewBag.Room = room;

            //var cheak = aManager.CheakTimeandRoom(rooms);
            

            //if (aRoom != aclasRoom)
            //{
            //    ViewBag.message = "Time Overlap";
            //}
            //if(aRoom == aclasRoom)
            //{
            //    
            //}

            //if (aRoom.RoomNo==aRoom.Day)
            //{
            //    ViewBag.message = "please Cheak Your dept,day,and Room that are overlap!";
            //}
            //else
            //{
            var aclasRoom = aManager.ifExitsTime(aRoom);
            if (aRoom.From >= aclasRoom.To && aRoom.To >= aclasRoom.From)
            {

                int rowweffected = aManager.SaveAllocateClassRoom(aRoom);
                if (rowweffected > 0)
                {
                    ViewBag.message = "Save Sucessfully ";
                }
                else
                {
                    ViewBag.message = "Sava Faild!";
                }
            }
            else
            {
                ViewBag.message = "Time Overlap";
            }
               // if (aRoom.From>=aRoom.To && aRoom.To>=aRoom.From)
               // {
               //     int rowweffected = aManager.SaveAllocateClassRoom(aRoom);
               //     if (rowweffected > 0)
               //     {
               //         ViewBag.message = "Save Sucessfully ";
               //     }
               //     else
               //     {
               //         ViewBag.message = "Sava Faild!";
               //     }
               // }
               //else
               // {
               //     ViewBag.message = "Time Overlap";
               // }
            
            return View();
        }


        public JsonResult GetSelectCourse(int Ids)
        {
            var course = aManager.GetAllCourse();
            var courseList = course.Where(a => a.DepartmentId == Ids).ToList();
            return Json(courseList, JsonRequestBehavior.AllowGet);
        }
	}
}