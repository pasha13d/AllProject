using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    class Country:MyBase
    {
        public int Id { get; set; }
        public string Name { get; set; }

        

        public bool Insert()
        {
            MyCommand = CommandBuilder(@"insert into country(name) 
                                values(@name)");
            MyCommand.Parameters.AddWithValue("@name", Name);
            return ExecuteNQ(MyCommand);
        }
        

        public bool Update()
        {

            MyCommand = CommandBuilder(@"update country set name = @name where id = @id");

            MyCommand.Parameters.AddWithValue("@id", Id);
            MyCommand.Parameters.AddWithValue("@name", Name);

            return ExecuteNQ(MyCommand);
        }

        public bool Delete(string ids = "")
        {
            if(ids == "")
            {
                MyCommand = CommandBuilder(@"delete from country where id = @id");
                MyCommand.Parameters.AddWithValue("@id", Id);
            }
            else
            {
                MyCommand = CommandBuilder(@"delete from country where id in ("+ids+")");
            }
           

           

            return ExecuteNQ(MyCommand);
        }

        public bool SelectById()
        {

            MyCommand = CommandBuilder(@"select id, name from country where id = @id");
            MyCommand.Parameters.AddWithValue("@id", Id);

            MyReader = ExecuteReader(MyCommand);

            while(MyReader.Read())
            {
                Name = MyReader["name"].ToString();
                return true;
            }
            return false;
        }

        public DataSet Select()
        {
            MyCommand = CommandBuilder("select id, name from country");
            if(!string.IsNullOrEmpty(Search))
            {
                MyCommand.CommandText += " where name like @search";
                MyCommand.Parameters.AddWithValue("@search", "%" + Search + "%");
            }
            return ExecuteDataSet(MyCommand);

        }

    }
}
