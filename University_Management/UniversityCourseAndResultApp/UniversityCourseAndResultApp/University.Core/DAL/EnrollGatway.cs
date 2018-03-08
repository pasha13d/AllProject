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
    public class EnrollGatway
    {
        string connectionString = WebConfigurationManager.ConnectionStrings["connection"].ConnectionString;

        public int EnrollStudent(EnrollCourse aEnroll)
        {
            SqlConnection connection = new SqlConnection(connectionString);

            string queary = "insert into tbl_Enrols(RegNo,Name,Email,Id,Dates)VALUES('" + aEnroll.StudentRegNo + "','" + aEnroll.Name + "','" + aEnroll.Email + "','" + aEnroll.DepartmentId + "','" + aEnroll.Dates + "')";
            //string queary = "insert into tbl_Enrols(RegNo,Name,Email,Id,CourseID,Date)values(@reg,@name,@email,@id,@courseid,@date)";
            SqlCommand command = new SqlCommand(queary, connection);

            //command.Parameters.Add("@reg", SqlDbType.VarChar);
            //command.Parameters["@reg"].Value = aEnroll.StudentRegNo;

            //command.Parameters.Add("@name", SqlDbType.VarChar);
            //command.Parameters["@name"].Value = aEnroll.Name;


            //command.Parameters.Add("@email", SqlDbType.VarChar);
            //command.Parameters["@email"].Value = aEnroll.Email;

            //command.Parameters.Add("@id", SqlDbType.Int);
            //command.Parameters["@id"].Value = aEnroll.DepartmentId;

            //command.Parameters.Add("@courseid", SqlDbType.Int);
            //command.Parameters["@courseid"].Value = aEnroll.C_Id;

            //command.Parameters.Add("@date", SqlDbType.VarChar);
            //command.Parameters["@date"].Value = aEnroll.Dates;

            //command.Parameters.Add("@regno",regno);
            //command.Parameters["@regno"].Value = aStudent.RegNo;

            connection.Open();

            int roweffected = command.ExecuteNonQuery();

            connection.Close();
            return roweffected;
        }

        public int ResultStudent(EnrollCourse aEnroll)
        {
            SqlConnection connection = new SqlConnection(connectionString);

            string queary = "insert into Results(RegNo,Name,Email,Id,CourseID,GradeId)VALUES('" + aEnroll.StudentRegNo + "','" + aEnroll.Name + "','" + aEnroll.Email + "','" + aEnroll.DepartmentId + "','" + aEnroll.C_Id + "','" + aEnroll.GradeId + "')";
            //string queary = "insert into tbl_Enrols(RegNo,Name,Email,Id,CourseID,Date)values(@reg,@name,@email,@id,@courseid,@date)";
            SqlCommand command = new SqlCommand(queary, connection);

            //command.Parameters.Add("@reg", SqlDbType.VarChar);
            //command.Parameters["@reg"].Value = aEnroll.StudentRegNo;

            //command.Parameters.Add("@name", SqlDbType.VarChar);
            //command.Parameters["@name"].Value = aEnroll.Name;


            //command.Parameters.Add("@email", SqlDbType.VarChar);
            //command.Parameters["@email"].Value = aEnroll.Email;

            //command.Parameters.Add("@id", SqlDbType.Int);
            //command.Parameters["@id"].Value = aEnroll.DepartmentId;

            //command.Parameters.Add("@courseid", SqlDbType.Int);
            //command.Parameters["@courseid"].Value = aEnroll.C_Id;

            //command.Parameters.Add("@date", SqlDbType.VarChar);
            //command.Parameters["@date"].Value = aEnroll.Dates;

            //command.Parameters.Add("@regno",regno);
            //command.Parameters["@regno"].Value = aStudent.RegNo;

            connection.Open();

            int roweffected = command.ExecuteNonQuery();

            connection.Close();
            return roweffected;
        }
    }
}