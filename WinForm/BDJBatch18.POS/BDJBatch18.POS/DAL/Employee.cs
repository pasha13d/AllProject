using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    class Employee : MyBase
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Contact { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Type { get; set; }

        public bool insert()
        {
            MyCommand = CommandBuilder(@"insert into employee (name, contact, email, password, type) values (@name, @contact, @email, @password, @type)");
            MyCommand.Parameters.AddWithValue("@name", Name);
            MyCommand.Parameters.AddWithValue("@contact", Contact);
            MyCommand.Parameters.AddWithValue("@email", Email);
            MyCommand.Parameters.AddWithValue("@password", Password);
            MyCommand.Parameters.AddWithValue("@type", Type);
            return ExecuteNQ(MyCommand);
        }

        public bool update()
        {
            MyCommand = CommandBuilder(@"update employee set name = @name, contact = @contact, email = @email, password = @password, type = @type where id = @id");
            MyCommand.Parameters.AddWithValue("@id", Id);
            MyCommand.Parameters.AddWithValue("@name", Name);
            MyCommand.Parameters.AddWithValue("@contact", Contact);
            MyCommand.Parameters.AddWithValue("@email", Email);
            MyCommand.Parameters.AddWithValue("@password", Password);
            MyCommand.Parameters.AddWithValue("@type", Type);
            return ExecuteNQ(MyCommand);
        }

        public bool delete (string ids = "")
        {
            if(ids != "")
            {
                MyCommand = CommandBuilder(@"delete from employee where id in " + ids + "");
            }
            else
            {
                MyCommand = CommandBuilder("delete from employee where id = @id");
                MyCommand.Parameters.AddWithValue("@id", Id);
            }
            return ExecuteNQ(MyCommand);
        }

        public bool selectById()
        {
            MyCommand = CommandBuilder(@"select id, name, contact, email, password, type from employee where id = @id");
            MyCommand.Parameters.AddWithValue("@id", Id);
            MyReader = ExecuteReader(MyCommand);

            while (MyReader.Read())
            {
                Name = MyReader["name"].ToString();
                Contact = MyReader["contact"].ToString();
                Email = MyReader["email"].ToString();
                Password = MyReader["password"].ToString();
                Type = MyReader["type"].ToString();

                return true;
            }
            return false;
        }

        public DataSet select()
        {
            MyCommand = CommandBuilder(@"select id, name, contact, email, password, type from employee where id > 0 ");
            if (!string.IsNullOrEmpty(Search))
            {
                MyCommand.CommandText += "and (name like @search or contact like @search or email like @search or type like @search)";
                MyCommand.Parameters.AddWithValue("@search", Search);
            }
            return ExecuteDataSet(MyCommand);
        }
    }
}
