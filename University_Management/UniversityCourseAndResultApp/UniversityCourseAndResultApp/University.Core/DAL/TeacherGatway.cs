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
    public class TeacherGatway
    {
        string connectionString = WebConfigurationManager.ConnectionStrings["connection"].ConnectionString;

        public int SaveTeacher(Teacher aTeacher)
        {
            SqlConnection connection = new SqlConnection(connectionString);

            string queary = "insert into tbl_Teacher(Name,Address,Email,Contact,DesignationId,Id,Credict)values(@name,@address,@email,@contact,@designationid,@id,@credit)";
            SqlCommand command = new SqlCommand(queary, connection);

            command.Parameters.Add("@name", SqlDbType.VarChar);
            command.Parameters["@name"].Value = aTeacher.Name;

            command.Parameters.Add("@address", SqlDbType.VarChar);
            command.Parameters["@address"].Value = aTeacher.Address;

            command.Parameters.Add("@email", SqlDbType.VarChar);
            command.Parameters["@email"].Value = aTeacher.Email;

            command.Parameters.Add("@contact", SqlDbType.VarChar);
            command.Parameters["@contact"].Value = aTeacher.ContactNo;

            command.Parameters.Add("@designationid", SqlDbType.Int);
            command.Parameters["@designationid"].Value = aTeacher.DeginationId;

            command.Parameters.Add("@id", SqlDbType.Int);
            command.Parameters["@id"].Value = aTeacher.DepartmentId;

            command.Parameters.Add("@credit", SqlDbType.Decimal);
            command.Parameters["@credit"].Value = aTeacher.Credit;


            connection.Open();

            int roweffected = command.ExecuteNonQuery();

            connection.Close();
            return roweffected;
        }
        public List<Designation> GetAllDesignat()
        {
            SqlConnection connection = new SqlConnection(connectionString);

            string queary = "select * from tbl_Designation";

            SqlCommand command = new SqlCommand(queary, connection);

            connection.Open();

            SqlDataReader reader = command.ExecuteReader();

            Designation aDesignation = null;
            List<Designation> aDesignationList = new List<Designation>();

            while (reader.Read())
            {
                aDesignation = new Designation();
                aDesignation.Id = (int)reader["DesignationId"];
                aDesignation.DesinationName = reader["DesinationName"].ToString();

                aDesignationList.Add(aDesignation);
            }
            reader.Close();
            connection.Close();
            return aDesignationList;
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

        public Teacher IfEmailExits(Teacher aTeacher)
        {
            SqlConnection connection = new SqlConnection(connectionString);

            string queary = "select * from tbl_Teacher where Email='" + aTeacher.Email + "'";

            SqlCommand command = new SqlCommand(queary, connection);

            connection.Open();

            SqlDataReader reader = command.ExecuteReader();

            Teacher teacher = null;

            while (reader.Read())
            {
                teacher = new Teacher();
                teacher.T_Id = (int)reader["TeachID"];
                teacher.Name = reader["Name"].ToString();
                teacher.Address = reader["Address"].ToString();
                teacher.Email  = reader["Email"].ToString();
                teacher.ContactNo = reader["Contact"].ToString();
                teacher.DeginationId = (int)reader["DesignationId"];
                teacher.DepartmentId = (int)reader["Id"];
                teacher.Credit = Convert.ToDecimal(reader["Credict"]);
            }
            reader.Close();
            connection.Close();
            return teacher;
        }

        public List<Teacher> GetAllTeacherList()
        {
            SqlConnection connection = new SqlConnection(connectionString);

            string queary = "select * from tbl_Teacher";

            SqlCommand command = new SqlCommand(queary, connection);

            connection.Open();

            SqlDataReader reader = command.ExecuteReader();

            Teacher aTeacher = null;
            List<Teacher> aTeacherList = new List<Teacher>();

            while (reader.Read())
            {
                aTeacher = new Teacher();
                aTeacher.T_Id = (int)reader["TeachID"];
                aTeacher.Name = reader["Name"].ToString();
                aTeacher.Address = reader["Address"].ToString();
                aTeacher.Email = reader["Email"].ToString();
                aTeacher.ContactNo = reader["Contact"].ToString();
                aTeacher.DeginationId = (int)reader["DesignationId"];
                aTeacher.DepartmentId = (int)reader["Id"];
                aTeacher.Credit = Convert.ToDecimal(reader["Credict"]);

                aTeacherList.Add(aTeacher);
            }
            reader.Close();
            connection.Close();
            return aTeacherList;
        }

        public List<Course> ShowAllCourse()
        {
            SqlConnection connection = new SqlConnection(connectionString);

            string queary = "select * from tbl_Course";

            SqlCommand command = new SqlCommand(queary, connection);

            connection.Open();

            SqlDataReader reader = command.ExecuteReader();
            List<Course> CourseList = new List<Course>();
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
                CourseList.Add(course);
            }
            reader.Close();
            connection.Close();
            return CourseList;
        }
    }
}