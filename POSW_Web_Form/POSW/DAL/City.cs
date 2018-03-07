using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    class City:MyBase
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CountryId { get; set; }

        public bool Insert()
        {
            MyCommand = CommandBuilder(@"insert into city(name) 
                                values(@name)");
            MyCommand.Parameters.AddWithValue("@name", Name);
            return ExecuteNQ(MyCommand);
        }
        

        public bool Update()
        {

            MyCommand = CommandBuilder(@"update city set name = @name where id = @id");

            MyCommand.Parameters.AddWithValue("@id", Id);
            MyCommand.Parameters.AddWithValue("@name", Name);

            return ExecuteNQ(MyCommand);
        }

        public bool Delete()
        {

            MyCommand = CommandBuilder(@"delete from city where id = @id");

            MyCommand.Parameters.AddWithValue("@id", Id);

            return ExecuteNQ(MyCommand);
        }

        public bool SelectById()
        {

            MyCommand = CommandBuilder(@"select id, name from city where id = @id");

            MyCommand.Parameters.AddWithValue("@id", Id);


            MyReader = ExecuteReader(MyCommand);

            while (MyReader.Read())
            {
                Name = MyReader["name"].ToString();
                return true;
            }
            //Error = "No Data Found";
            return false;
        }

        public DataSet Select()
        {
            MyCommand = CommandBuilder(@"select ct.id, ct.name, cn.name as country from city as ct left join country as cn on ct.countryId = cn.id where ct.id > 0");

            if(!string.IsNullOrEmpty(Search))
            {
                MyCommand.CommandText += " and ct.name like @search";
                MyCommand.Parameters.AddWithValue("@search", "%" + Search + "%");
            }
            if(CountryId > 0)
            {
                MyCommand.CommandText += " and cn.id = @countryId";
                MyCommand.Parameters.AddWithValue("@countryId", CountryId);
            }

            return ExecuteDataSet(MyCommand);
        }

    }
}
