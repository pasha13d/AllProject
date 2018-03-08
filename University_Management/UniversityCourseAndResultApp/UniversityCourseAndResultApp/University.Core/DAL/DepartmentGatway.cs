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
    public class DepartmentGatway
    {
        string connectionString = WebConfigurationManager.ConnectionStrings["connection"].ConnectionString;

        public int SaveDepartment(Department aDepartment)
        {
            SqlConnection connection = new SqlConnection(connectionString);

            string queary = "insert into Department(Code,Name)values(@code,@name)";

            SqlCommand command = new SqlCommand(queary, connection);

            command.Parameters.Add("@code", SqlDbType.VarChar);
            command.Parameters["@code"].Value = aDepartment.Code;

            command.Parameters.Add("@name", SqlDbType.VarChar);
            command.Parameters["@name"].Value = aDepartment.Name;

            connection.Open();

            int roweffected = command.ExecuteNonQuery();

            connection.Close();
            return roweffected;
            
        }

        public Department IfCodeExit(Department aDepartment)
        {
            SqlConnection connection = new SqlConnection(connectionString);

            string queary = "select * from Department where Code='"+aDepartment.Code+"'";

            SqlCommand command = new SqlCommand(queary, connection);

            connection.Open();

            SqlDataReader reader = command.ExecuteReader();

            Department Department = null;
            
            while(reader.Read())
            {
                Department = new Department();
                Department.Id = (int)reader["Id"];
                Department.Code = reader["Code"].ToString();
                Department.Name = reader["Name"].ToString();
            }
            reader.Close();
            connection.Close();
            return Department;
        }

        public Department ifNameExit(Department aDepartment)
        {
            SqlConnection connection = new SqlConnection(connectionString);

            string queary = "select * from Department where Name='" + aDepartment.Name + "'";

            SqlCommand command = new SqlCommand(queary, connection);

            connection.Open();

            SqlDataReader reader = command.ExecuteReader();

            Department Department = null;

            while (reader.Read())
            {
                Department = new Department();
                Department.Id = (int)reader["Id"];
                Department.Code = reader["Code"].ToString();
                Department.Name = reader["Name"].ToString();
            }
            reader.Close();
            connection.Close();
            return Department;
        }

        public List<Department>ShowAllDepartments(Department aDepartment)
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
    }
}