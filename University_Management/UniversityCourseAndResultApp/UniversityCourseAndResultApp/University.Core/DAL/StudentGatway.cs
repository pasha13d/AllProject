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
    public class StudentGatway
    {
        string connectionString = WebConfigurationManager.ConnectionStrings["connection"].ConnectionString;

        public int SaveStudent(Student aStudent,string Regnos)
        {
            SqlConnection connection = new SqlConnection(connectionString);

            //string queary = "insert into tbl_Student(StudentName,Email,Contact,Dates,Addres,Id)VALUES('" + aStudent.Name + "','" + aStudent.Email + "','" + aStudent.ContactNo + "','" + aStudent.Date + "','" + aStudent.Address + "','" + aStudent.Id + "')";
            string queary = "insert into tbl_Student(Name,Email,ContactNo,Dates,Addres,RegNo,Id)values(@studentName,@email,@contact,@date,@address,@regno,@id)";
          
            SqlCommand command = new SqlCommand(queary, connection);

            //command.Parameters.Add("@studentName", SqlDbType.VarChar);
            //command.Parameters["@studentName"].Value = aStudent.Name;

            //command.Parameters.Add("@email", SqlDbType.VarChar);
            //command.Parameters["@email"].Value = aStudent.Email;


            //command.Parameters.Add("@contact", SqlDbType.VarChar);
            //command.Parameters["@contact"].Value = aStudent.ContactNo;

            //command.Parameters.Add("@date", SqlDbType.Date);
            //command.Parameters["@date"].Value = aStudent.BirthDate;

            //command.Parameters.Add("@address", SqlDbType.VarChar);
            //command.Parameters["@address"].Value = aStudent.Address;

            //command.Parameters.AddWithValue("@regno", Regnos);

            ////command.Parameters.Add("@regno", Regnos);
            ////command.Parameters["@regno"].Value = aStudent.RegNo;

            //command.Parameters.Add("@id", SqlDbType.Int);
            //command.Parameters["@id"].Value = aStudent.DeptId;
            command.CommandText = queary;
            command.Parameters.Clear();
            command.Parameters.AddWithValue("@studentName", aStudent.Name);
            command.Parameters.AddWithValue("@email", aStudent.Email);
            command.Parameters.AddWithValue("@contact", aStudent.ContactNo);
            command.Parameters.AddWithValue("@date", aStudent.BirthDate);
            command.Parameters.AddWithValue("@address", aStudent.Address);
            command.Parameters.AddWithValue("@regno", Regnos);
            command.Parameters.AddWithValue("@id", aStudent.DeptId);
            
            
           
            connection.Open();

            var roweffected = command.ExecuteNonQuery();

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

        public List<Student> ShowAllStudent()
        {
            SqlConnection connection = new SqlConnection(connectionString);

            string queary = "select * from tbl_Student";

            SqlCommand command = new SqlCommand(queary, connection);

            connection.Open();

            SqlDataReader reader = command.ExecuteReader();

            Student aStudent = null;
            List<Student> aStudentList = new List<Student>();

            while (reader.Read())
            {
                aStudent = new Student();
                aStudent.Id = (int)reader["St_id"];
                aStudent.Name = reader["Name"].ToString();
                aStudent.Email = reader["Email"].ToString();
                aStudent.ContactNo = reader["ContactNo"].ToString();
                aStudent.BirthDate = Convert.ToDateTime(reader["Dates"]);
                aStudent.Address = reader["Addres"].ToString();
                aStudent.RegNo = reader["RegNo"].ToString();
                aStudent.DeptId = (int)reader["Id"];
                aStudentList.Add(aStudent);
            }
            reader.Close();
            connection.Close();
            return aStudentList;
        }

        public Student IfEmailExits(Student aStudent)
        {
            SqlConnection connection = new SqlConnection(connectionString);

            string queary = "select * from tbl_Student where Email='" + aStudent.Email + "'";

            SqlCommand command = new SqlCommand(queary, connection);

            connection.Open();

            SqlDataReader reader = command.ExecuteReader();

            Student Student = null;

            while (reader.Read())
            {
                Student = new Student();
                Student.Id = (int)reader["St_id"];
                Student.Name = reader["Name"].ToString();
                Student.Email = reader["Email"].ToString();
                Student.ContactNo = reader["ContactNo"].ToString();
                aStudent.BirthDate = Convert.ToDateTime(reader["Dates"]);
                Student.Address = reader["Addres"].ToString();
                Student.DeptId = (int)reader["Id"];
                
            }
            reader.Close();
            connection.Close();
            return Student;
        }


        public List<EnrollCourse> StudentDepartment()
        {
            SqlConnection connection = new SqlConnection(connectionString);

            string queary = "select * from VW_StudentDepartment";

            SqlCommand command = new SqlCommand(queary, connection);

            connection.Open();

            SqlDataReader reader = command.ExecuteReader();

            EnrollCourse aStudent = null;
            List<EnrollCourse> aStudentList = new List<EnrollCourse>();

            while (reader.Read())
            {
                aStudent = new EnrollCourse();
                aStudent.E_Id = (int)reader["St_id"];
                aStudent.StudentRegNo = reader["RegNo"].ToString();
                aStudent.DepartmentId = (int)reader["id"];
                aStudent.DepartmentName = reader["DepartmentName"].ToString();
                aStudentList.Add(aStudent);
            }
            reader.Close();
            connection.Close();
            return aStudentList;
        }

        public List<CourseStudent> GetAllCourse()
        {
            SqlConnection connection = new SqlConnection(connectionString);

            string queary = "select*from Vw_CourseStus";

            SqlCommand command = new SqlCommand(queary, connection);

            connection.Open();

            SqlDataReader reader = command.ExecuteReader();
            List<CourseStudent> aCourseList = new List<CourseStudent>();
            CourseStudent course = null;

            while (reader.Read())
            {
                course = new CourseStudent();
                course.Id = (int)reader["St_id"];             
                course.CourseName = reader["CourseName"].ToString();
                course.RegNo = reader["RegNo"].ToString();
                course.DeptId = (int)reader["Id"];
                //course.RegNo = reader["RegNo"].ToString();
                //course.Credit = Convert.ToDecimal(reader["Credit"]);
                //course.Description = reader["Description"].ToString();
                //course.DepartmentId = (int)reader["Id"];
                //course.SemesterId = (int)reader["SemID"];
                aCourseList.Add(course);
            }
            reader.Close();
            connection.Close();
            return aCourseList;
        }

        public List<Grade> GetAllGrade()
        {
            SqlConnection connection = new SqlConnection(connectionString);

            string queary = "select * from tbl_Grade";

            SqlCommand command = new SqlCommand(queary, connection);

            connection.Open();

            SqlDataReader reader = command.ExecuteReader();

            Grade grade = null;
            List<Grade> gradeList = new List<Grade>();

            while (reader.Read())
            {
                grade = new Grade();
                grade.GId = (int)reader["GradeId"];
                grade.Grades = reader["Grade"].ToString();
                gradeList.Add(grade);
            }
            reader.Close();
            connection.Close();
            return gradeList;
        }
    }
}