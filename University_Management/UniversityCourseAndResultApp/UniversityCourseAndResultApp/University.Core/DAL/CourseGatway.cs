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
    public class CourseGatway
    {
        string connectionString = WebConfigurationManager.ConnectionStrings["connection"].ConnectionString;

        public int SaveCourse(Course aCourse)
        {
            SqlConnection connection = new SqlConnection(connectionString);

            string queary = "insert into tbl_Course(Code,Name,Credit,Description,Id,SemID)values(@code,@name,@credit,@description,@id,@semid)";
            SqlCommand command = new SqlCommand(queary, connection);

            command.Parameters.Add("@code", SqlDbType.VarChar);
            command.Parameters["@code"].Value = aCourse.Code;

            command.Parameters.Add("@name", SqlDbType.VarChar);
            command.Parameters["@name"].Value = aCourse.Name;

            command.Parameters.Add("@credit", SqlDbType.Decimal);
            command.Parameters["@credit"].Value = aCourse.Credit;

            command.Parameters.Add("@description", SqlDbType.VarChar);
            command.Parameters["@description"].Value = aCourse.Description;

            command.Parameters.Add("@id", SqlDbType.Int);
            command.Parameters["@id"].Value = aCourse.DepartmentId;

            command.Parameters.Add("@semid", SqlDbType.Int);
            command.Parameters["@semid"].Value = aCourse.SemesterId;

            connection.Open();

            int roweffected = command.ExecuteNonQuery();

            connection.Close();
            return roweffected;
        }
        public List<Semester> GetAllSemester()
        {
            SqlConnection connection = new SqlConnection(connectionString);

            string queary = "select * from tbl_Semester";

            SqlCommand command = new SqlCommand(queary, connection);

            connection.Open();

            SqlDataReader reader = command.ExecuteReader();

            Semester aSemester = null;
            List<Semester> aSemesterList = new List<Semester>();

            while (reader.Read())
            {
                aSemester = new Semester();
                aSemester.SemId = (int)reader["SemID"];
                aSemester.Name = reader["SemName"].ToString();
                
                aSemesterList.Add(aSemester);
            }
            reader.Close();
            connection.Close();
            return aSemesterList;
        }

        public List<Department> GetAllDepartmentList()
        {
            SqlConnection connection = new SqlConnection(connectionString);

            string queary = "select * from Department";

            SqlCommand command = new SqlCommand(queary, connection);

            connection.Open();

            SqlDataReader reader = command.ExecuteReader();

            Department aDepartment = null;
            List<Department> aDepartmentList = new List<Department>();

            while (reader.Read())
            {
                aDepartment = new Department();
                aDepartment.Id = (int)reader["Id"];
                aDepartment.Code = reader["Code"].ToString();
                aDepartment.Name = reader["Name"].ToString();

                aDepartmentList.Add(aDepartment);
            }
            reader.Close();
            connection.Close();
            return aDepartmentList;
        }

        public Course IfCodeExit(Course aCourse)
        {
            SqlConnection connection = new SqlConnection(connectionString);

            string queary = "select * from tbl_Course where Code='" + aCourse.Code + "'";

            SqlCommand command = new SqlCommand(queary, connection);

            connection.Open();

            SqlDataReader reader = command.ExecuteReader();

            Course course = null;

            while (reader.Read())
            {
                course = new Course();
                course.C_Id = (int)reader["CourseID"];
                course.Code = reader["Code"].ToString();
                course.Name = reader["Name"].ToString();
                course.Credit =Convert.ToDecimal(reader["Credit"]);
                course.Description = reader["Description"].ToString();
                course.DepartmentId = (int)reader["Id"];
                course.SemesterId = (int)reader["SemID"];
            }
            reader.Close();
            connection.Close();
            return course;
        }

        public Course IfNameExit(Course aCourse)
        {
            SqlConnection connection = new SqlConnection(connectionString);

            string queary = "select * from tbl_Course where Name='" + aCourse.Name + "'";

            SqlCommand command = new SqlCommand(queary, connection);

            connection.Open();

            SqlDataReader reader = command.ExecuteReader();

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
            }
            reader.Close();
            connection.Close();
            return course;
        }

        
    }
}