using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityCourseAndResultApp.University.Core.DAL;
using UniversityCourseAndResultApp.Models;
namespace UniversityCourseAndResultApp.University.Core.BLL
{
    public class AllocateClassroomManager
    {
        AllocateClassroomGatway aGatway = new AllocateClassroomGatway();


        public int SaveAllocateClassRoom(AllocateClassroom aRoom)
        {
            return aGatway.SaveAllocateClassRoom(aRoom);
        }

        public AllocateClassroom ifExitsTime(AllocateClassroom aClassRoom)
        {
            return aGatway.ifExitsTime(aClassRoom);
        }
        public List<Department> ShowAllDepartment()
        {
            return aGatway.ShowAllDepartment();
        }

        public List<Course> ShowAllCourse()
        {
            return aGatway.ShowAllCourse();
        }

        public List<SevenDay> ShowAllDay()
        {
            return aGatway.ShowAllDay();
        }
        public List<Room> ShowAllRoom()
        {
            return aGatway.ShowAllRoom();
        }

        public AllocateClassroom CheakTimeandRoom(AllocateClassroom room)
        {
            return aGatway.CheakTimeandRoom(room);
        }

        public List<Course> GetAllCourse()
        {
            return aGatway.GetAllCourse();
        }
    }
}