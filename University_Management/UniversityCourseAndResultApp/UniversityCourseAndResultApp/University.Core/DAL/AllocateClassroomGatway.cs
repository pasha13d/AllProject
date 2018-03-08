using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Data.SqlClient;
using UniversityCourseAndResultApp.Models;
using System.Data;


namespace UniversityCourseAndResultApp.University.Core.DAL
{
 
    public class AllocateClassroomGatway
    {
        string connectionString = WebConfigurationManager.ConnectionStrings["connection"].ConnectionString;

        public int SaveAllocateClassRoom(AllocateClassroom aRoom)
        {
            SqlConnection connection = new SqlConnection(connectionString);

            //string queary = "insert into tbl_Student(StudentName,Email,Contact,Dates,Addres,Id)VALUES('" + aStudent.Name + "','" + aStudent.Email + "','" + aStudent.ContactNo + "','" + aStudent.Date + "','" + aStudent.Address + "','" + aStudent.Id + "')";
            string queary = "insert into  tbl_Allocateion(Id,CourseName,RoomName,Day,Forms,Tows)values(@id,@course,@room,@day,@fromdate,@todate)";
            SqlCommand command = new SqlCommand(queary, connection);

            command.Parameters.Add("@id", SqlDbType.Int);
            command.Parameters["@id"].Value = aRoom.DepartmentId;

            command.Parameters.Add("@course", SqlDbType.VarChar);
            command.Parameters["@course"].Value = aRoom.CourseName;


            command.Parameters.Add("@room", SqlDbType.VarChar);
            command.Parameters["@room"].Value = aRoom.RoomNo;

            command.Parameters.Add("@day", SqlDbType.VarChar);
            command.Parameters["@day"].Value = aRoom.Day;

            command.Parameters.Add("@fromdate", SqlDbType.Time);
            command.Parameters["@fromdate"].Value = aRoom.From;

            command.Parameters.Add("@todate", SqlDbType.Time);
            command.Parameters["@todate"].Value = aRoom.To;

            connection.Open();

            int roweffected = command.ExecuteNonQuery();

            connection.Close();
            return roweffected;
        }
        
        public List<Department> ShowAllDepartment()
        {
            SqlConnection connection = new SqlConnection(connectionString);

            string queary = "select * from Department";

            SqlCommand command = new SqlCommand(queary, connection);

            connection.Open();

            SqlDataReader reader = command.ExecuteReader();

            Department Department = null;
            List<Department> aDepartmentList = new List<Department>();

            while (reader.Read())
            {
                Department = new Department();
                Department.Id = (int)reader["Id"];
                Department.Code = reader["Code"].ToString();
                Department.Name = reader["Name"].ToString();
                aDepartmentList.Add(Department);
            }
            reader.Close();
            connection.Close();
            return aDepartmentList;
        }

        public AllocateClassroom ifExitsTime(AllocateClassroom room)
        {
            SqlConnection connection = new SqlConnection(connectionString);

            //string queary = "select*from tbl_AllocateCla where id=" + aClassRoom.Department + " and CourseID="+aClassRoom.CourseName+" and RoomId="+aClassRoom.RoomNo+" and DayId="+aClassRoom.Day+" and Froms="+aClassRoom.From+"and Twos="+aClassRoom.To+"";

            string queary = "select*from tbl_Allocateion";

            SqlCommand command = new SqlCommand(queary, connection);

            connection.Open();

            SqlDataReader reader = command.ExecuteReader();

            AllocateClassroom classRoom = null;

            while (reader.Read())
            {
                classRoom = new AllocateClassroom();
                classRoom.AllocateClassroomId = (int)reader["Al_ID"];
                classRoom.DepartmentId = (int)reader["Id"];
                classRoom.CourseName = reader["CourseName"].ToString();
                classRoom.RoomNo =reader["RoomName"].ToString();
                classRoom.Day =reader["Day"].ToString();
                classRoom.From = (TimeSpan)reader["Forms"];
                classRoom.To =(TimeSpan) reader["Tows"];


            }
            reader.Close();
            connection.Close();
            return classRoom;
        }

        public List<Course> ShowAllCourse()
        {
            SqlConnection connection = new SqlConnection(connectionString);

            string queary = "select*from tbl_Course";

            SqlCommand command = new SqlCommand(queary, connection);

            connection.Open();

            SqlDataReader reader = command.ExecuteReader();
            List<Course> courseList = new List<Course>();
            Course course = null;

            while (reader.Read())
            {
                course = new Course();
                course.C_Id = (int)reader["CourseID"];
                course.Code = reader["Code"].ToString();
                course.Name = reader["Name"].ToString();
                course.Credit = Convert.ToDecimal(reader["Credit"]);
                course.Description = reader["Description"].ToString();
                course.DepartmentId = (int)reader["Id"];
                course.SemesterId = (int)reader["SemID"];
                courseList.Add(course);
            }
            reader.Close();
            connection.Close();
            return courseList;
        }

        public List<SevenDay> ShowAllDay()
        {
            SqlConnection connection = new SqlConnection(connectionString);

            string queary = "select*from tbl_SevenDay";

            SqlCommand command = new SqlCommand(queary, connection);

            connection.Open();

            SqlDataReader reader = command.ExecuteReader();
            List<SevenDay> sevenDayList = new List<SevenDay>();
            SevenDay aSevenDay = null;

            while (reader.Read())
            {
                aSevenDay = new SevenDay();
                aSevenDay.Id = (int)reader["DayId"];
                aSevenDay.Day = reader["Day"].ToString();
                sevenDayList.Add(aSevenDay);
            }
            reader.Close();
            connection.Close();
            return sevenDayList;
        }



        public List<Room> ShowAllRoom()
        {
            SqlConnection connection = new SqlConnection(connectionString);

            string queary = "select*from tbl_Room";

            SqlCommand command = new SqlCommand(queary, connection);

            connection.Open();

            SqlDataReader reader = command.ExecuteReader();
            List<Room> roomList = new List<Room>();
            Room aRoom = null;

            while (reader.Read())
            {
                aRoom = new Room();
                aRoom.Id = (int)reader["RoomId"];
                aRoom.RoomNumber = reader["RoomNo"].ToString();
                roomList.Add(aRoom);
            }
            reader.Close();
            connection.Close();
            return roomList;
        }

        public AllocateClassroom CheakTimeandRoom(AllocateClassroom room)
        {
            SqlConnection connection = new SqlConnection(connectionString);

            //string queary = "select*from tbl_AllocateCla where id=" + aClassRoom.Department + " and CourseID="+aClassRoom.CourseName+" and RoomId="+aClassRoom.RoomNo+" and DayId="+aClassRoom.Day+" and Froms="+aClassRoom.From+"and Twos="+aClassRoom.To+"";

            string queary = "select*from tbl_Allocateion where  RoomId=" + room.RoomNo + "";

            SqlCommand command = new SqlCommand(queary, connection);

            connection.Open();

            SqlDataReader reader = command.ExecuteReader();

            AllocateClassroom classRoom = null;

            while (reader.Read())
            {
                classRoom = new AllocateClassroom();
                classRoom.AllocateClassroomId = (int)reader["Al_ID"];
                classRoom.DepartmentId = (int)reader["Id"];
                classRoom.CourseName = reader["CourseName"].ToString();
                classRoom.RoomNo = reader["RoomName"].ToString();
                classRoom.Day = reader["Day"].ToString();
                classRoom.From = (TimeSpan)reader["Forms"];
                classRoom.To = (TimeSpan)reader["Tows"];


            }
            reader.Close();
            connection.Close();
            return classRoom;
        }

        public List<Course> GetAllCourse()
        {
            SqlConnection connection = new SqlConnection(connectionString);

            string queary = "select * from tbl_Course";

            SqlCommand command = new SqlCommand(queary, connection);

            connection.Open();

            SqlDataReader reader = command.ExecuteReader();

            Course course = null;
            List<Course> courseList = new List<Course>();
            while (reader.Read())
            {
                course = new Course();
                course.C_Id = (int)reader["CourseID"];
                course.Code = reader["Code"].ToString();
                course.Name = reader["Name"].ToString();
                course.Credit = Convert.ToDecimal(reader["Credit"]);
                course.Description = reader["Description"].ToString();
                course.DepartmentId = (int)reader["Id"];
                course.SemesterId = (int)reader["SemID"];
                courseList.Add(course);
            }
            reader.Close();
            connection.Close();
            return courseList;
        }
    }
}