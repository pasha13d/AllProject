using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    class Unit : MyBase
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int PrimaryQty { get; set; }

        public bool insert()
        {
            MyCommand = CommandBuilder(@"insert into unit (name, description, primaryQty) values (@name, @description, @primaryQty)");
            MyCommand.Parameters.AddWithValue("@name", Name);
            MyCommand.Parameters.AddWithValue("@description", Description);
            MyCommand.Parameters.AddWithValue("@primaryQty", PrimaryQty);

            return ExecuteNQ(MyCommand);
        }

        public bool update()
        {
            MyCommand = CommandBuilder(@"update unit set name = @name, description = @description, primaryQty = @primaryQty where id = @id");
            MyCommand.Parameters.AddWithValue("@id", Id);
            MyCommand.Parameters.AddWithValue("@name", Name);
            MyCommand.Parameters.AddWithValue("@description", Description);
            MyCommand.Parameters.AddWithValue("@primaryQty", PrimaryQty);

            return ExecuteNQ(MyCommand);
        }

        public bool delete (string ids = "")
        {
            if(ids != "")
            {
                MyCommand = CommandBuilder(@"delete from unit where id in " + ids + "");
            }
            else
            {
                MyCommand = CommandBuilder("delete from unit where id = @id");
                MyCommand.Parameters.AddWithValue("@id", Id);
            }


            return ExecuteNQ(MyCommand);
        }

        public bool selectById()
        {
            MyCommand = CommandBuilder(@"select id, name, description, primaryQty from unit where id = @id");
            MyCommand.Parameters.AddWithValue("@id", Id);
            MyReader = ExecuteReader(MyCommand);

            while (MyReader.Read())
            {
                Name = MyReader["name"].ToString();
                Description = MyReader["description"].ToString();
                PrimaryQty = Convert.ToInt32(MyReader["primaryQty"]);
                return true;
            }
            return false;
        }

        public DataSet Select()
        {
            MyCommand = CommandBuilder(@"select id, name, description, primaryQty from unit where id > 0");

            if (!string.IsNullOrEmpty(Search))
            {
                MyCommand.CommandText += " and ( name like @search or description like @search";
                MyCommand.Parameters.AddWithValue("@search","%"+Search+"%");
            }
            return ExecuteDataSet(MyCommand);
        }
    }
}
