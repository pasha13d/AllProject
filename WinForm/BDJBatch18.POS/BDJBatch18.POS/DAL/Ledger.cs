using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Ledger : MyBase
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Contact { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Address { get; set;}
        public int CityId { get; set; }
        public DateTime CreateDate { get; set; }
        public byte[] Image { get; set; }
        public string Type { get; set; }

        public bool insert()
        {
            MyCommand = CommandBuilder(@"insert into ledger (name, contact, email, password, gender, dateOfBirth, address, cityId, createDate, image, type ) 
                                       values(@name, @contact, @email, @password, @gender,@dateOfBirth, @address, @cityId, @createDate, @image, @type)");
            MyCommand.Parameters.AddWithValue("@name", Name);
            MyCommand.Parameters.AddWithValue("@contact", Contact);
            MyCommand.Parameters.AddWithValue("@email", Email);
            MyCommand.Parameters.AddWithValue("@password", Password);
            MyCommand.Parameters.AddWithValue("@gender", Gender);
            MyCommand.Parameters.AddWithValue("@dateOfBirth", DateOfBirth);
            MyCommand.Parameters.AddWithValue("@address", Address);
            MyCommand.Parameters.AddWithValue("@cityId", CityId);
            MyCommand.Parameters.AddWithValue("@createDate", CreateDate);
            MyCommand.Parameters.AddWithValue("@image", Image);
            MyCommand.Parameters.AddWithValue("@type", Type);
            return ExecuteNQ(MyCommand);
        }

        public bool update()
        {
            MyCommand = CommandBuilder(@"update ledger set name = @name, contact = @contact, email = @email, password = @password, 
                                    gender = @gender, dateOfBirth = @dateOfBirth, address = @address, cityId = @cityId, createDate = @createDate, image = @image, 
                                    type = @type where id = @id");
            MyCommand.Parameters.AddWithValue("@id", Id);
            MyCommand.Parameters.AddWithValue("@name", Name);
            MyCommand.Parameters.AddWithValue("@contact", Contact);
            MyCommand.Parameters.AddWithValue("@email", Email);
            MyCommand.Parameters.AddWithValue("@password", Password);
            MyCommand.Parameters.AddWithValue("@gender", Gender);
            MyCommand.Parameters.AddWithValue("@dateOfBirth", DateOfBirth);
            MyCommand.Parameters.AddWithValue("@address", Address);
            MyCommand.Parameters.AddWithValue("@cityId", CityId);
            MyCommand.Parameters.AddWithValue("@createDate", CreateDate);
            MyCommand.Parameters.AddWithValue("@image", Image);
            MyCommand.Parameters.AddWithValue("@type", Type);

            return ExecuteNQ(MyCommand);

        }

        public bool delete(string ids = "")
        {
            if(ids != "")
            {
                MyCommand = CommandBuilder(@"delete from ledger where id in (" + ids + ")");
            }
            else
            {
                MyCommand = CommandBuilder("delete from ledger where id = @id");
                MyCommand.Parameters.AddWithValue("@id", Id);
            }

            return ExecuteNQ(MyCommand);
        }

        public bool selectById()
        {
            MyCommand = CommandBuilder(@"select id, name, contact, email, password, gender, dateOfBirth, address, cityId, createDate, image, type from ledger where id = @id");
            MyCommand.Parameters.AddWithValue("@id", Id);

            MyReader = ExecuteReader(MyCommand);
            while (MyReader.Read())
            {
                Name = MyReader["name"].ToString();
                Contact = MyReader["contact"].ToString();
                Email = MyReader["email"].ToString();
                Password = MyReader["password"].ToString();
                Gender = Convert.ToInt32(MyReader["gender"]);
                DateOfBirth =Convert.ToDateTime( MyReader["dateOfBirth"]);
                Address = MyReader["address"].ToString();
                CityId = Convert.ToInt32(MyReader["cityId"]);
                CreateDate = Convert.ToDateTime(MyReader["createDate"]);
                try
                {
                    Image = (byte[])MyReader["image"];
                }
                catch { }
                Type = MyReader["type"].ToString();
                return true;
            }
            return false;
        }

        public DataSet select()
        {
            MyCommand = CommandBuilder(@"select l.id, l.name, l.contact, l.email, l.password, l.gender, l.dateOfBirth, l.address, l.createDate, l.image, 
                                        l.type, ct.name as city from ledger as l left join city as ct on l.cityId = ct.id where l.id > 0");

            if (!string.IsNullOrEmpty(Search))
            {
                MyCommand.CommandText += @" and ( l.name like @search)";
                MyCommand.Parameters.AddWithValue("@search", "%" + Search + "%");
            }
            if (!string.IsNullOrEmpty(Contact))
            {
                MyCommand.CommandText += @" and ( l.contact like @contact)";
                MyCommand.Parameters.AddWithValue("@contact", "%" + Contact + "%");
            }
            if (!string.IsNullOrEmpty(Email))
            {
                MyCommand.CommandText += @" and ( l.email like @email)";
                MyCommand.Parameters.AddWithValue("@email", "%" + Email + "%");
            }
            if (CityId > 0)
            {
                MyCommand.CommandText += " and ct.id = @cityId";
                MyCommand.Parameters.AddWithValue("@cityId", CityId);
            }
            
            //dateSearch
            if(isDateSearch)
            {
                MyCommand.CommandText += (" and  l.dateOfBirth between @date1 and @date2");
                MyCommand.Parameters.AddWithValue("@date1", DateFrom);
                MyCommand.Parameters.AddWithValue("@date2", DateTo);
            }

            return ExecuteDataSet(MyCommand);
        }
    }
}
