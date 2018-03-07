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
        public string Address { get; set; }
        public int CityId { get; set; }

        public bool insert()
        {
            MyCommand = CommandBuilder(@"insert into employee (name, contact, email, password, type, address, cityId) values (@name, @contact, @email, @password, @type, @address, @cityId)");
            MyCommand.Parameters.AddWithValue("@name", Name);
            MyCommand.Parameters.AddWithValue("@contact", Contact);
            MyCommand.Parameters.AddWithValue("@email", Email);
            MyCommand.Parameters.AddWithValue("@password", Password);
            MyCommand.Parameters.AddWithValue("@type", Type);
            MyCommand.Parameters.AddWithValue("@address", Address);
            MyCommand.Parameters.AddWithValue("@cityId", CityId);
            return ExecuteNQ(MyCommand);
        }

        public bool update()
        {
            MyCommand = CommandBuilder(@"update employee set name = @name, contact = @contact, email = @email, password = @password, type = @type, address = @address, cityId = @cityId where id = @id");
            MyCommand.Parameters.AddWithValue("@id", Id);
            MyCommand.Parameters.AddWithValue("@name", Name);
            MyCommand.Parameters.AddWithValue("@contact", Contact);
            MyCommand.Parameters.AddWithValue("@email", Email);
            MyCommand.Parameters.AddWithValue("@password", Password);
            MyCommand.Parameters.AddWithValue("@type", Type);
            MyCommand.Parameters.AddWithValue("@address", Address);
            MyCommand.Parameters.AddWithValue("@cityId", CityId);
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
            MyCommand = CommandBuilder(@"select id, name, contact, email, password, type, address, cityId from employee where id = @id");
            MyCommand.Parameters.AddWithValue("@id", Id);
            MyReader = ExecuteReader(MyCommand);

            while (MyReader.Read())
            {
                Name = MyReader["name"].ToString();
                Contact = MyReader["contact"].ToString();
                Email = MyReader["email"].ToString();
                Password = MyReader["password"].ToString();
                Type = MyReader["type"].ToString();
                Address = MyReader["address"].ToString();
                CityId = (int)MyReader["cityId"];
                return true;
            }
            return false;
        }

        public bool selectByEmail()
        {
            MyCommand = CommandBuilder(@"select id, name, contact, email, password, type, address, cityId from employee where email = @email");
            MyCommand.Parameters.AddWithValue("@email", Email);
            MyReader = ExecuteReader(MyCommand);

            while (MyReader.Read())
            {
                Id = Convert.ToInt32(MyReader["id"]);
                Name = MyReader["name"].ToString();
                Contact = MyReader["contact"].ToString();
                Email = MyReader["email"].ToString();
                Password = MyReader["password"].ToString();
                Type = MyReader["type"].ToString();
                Address = MyReader["address"].ToString();
                CityId = (int)MyReader["cityId"];
                return true;
            }
            return false;
        }

        public bool Login()
        {
            MyCommand = CommandBuilder(@"select id, name, contact, email, password, type, address, cityId from employee where (email = @email or contact = @email) and password = @password");
            MyCommand.Parameters.AddWithValue("@email", Email);
            MyCommand.Parameters.AddWithValue("@password", Password);
            MyReader = ExecuteReader(MyCommand);

            while (MyReader.Read())
            {
                Id = Convert.ToInt32(MyReader["id"]);
                Name = MyReader["name"].ToString();
                Contact = MyReader["contact"].ToString();
                Email = MyReader["email"].ToString();
                Password = MyReader["password"].ToString();
                Type = MyReader["type"].ToString();
                Address = MyReader["address"].ToString();
                CityId = (int)MyReader["cityId"];
                return true;
            }
            return false;
        }

        public DataSet Select()
        {
            MyCommand = CommandBuilder(@"select e.id, e.name, e.contact, e.email, e.password, e.type, e.address, ct.name as city, cn.name as country from employee as e left join city as ct on e.cityId = ct.id left join country as cn on ct.countryId = cn.id where e.id > 0 ");
            if (!string.IsNullOrEmpty(Search))
            {
                MyCommand.CommandText += "and (e.name like @search or e.contact like @search or e.email like @search)";
                MyCommand.Parameters.AddWithValue("@search", Search);
            }
            return ExecuteDataSet(MyCommand);
        }
    }
}
