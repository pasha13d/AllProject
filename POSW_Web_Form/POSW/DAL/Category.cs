using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    class Category:MyBase
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }


        public bool Insert()
        {
            if(CategoryId > 0)
            {
                MyCommand = CommandBuilder(@"insert into category(name, description, categoryId) 
                                values(@name, @description, @categoryId)");
                MyCommand.Parameters.AddWithValue("@categoryId", CategoryId);
            }
            else
            {
                MyCommand = CommandBuilder(@"insert into category(name, description) 
                                values(@name, @description)");
            }
            MyCommand.Parameters.AddWithValue("@name", Name);
            MyCommand.Parameters.AddWithValue("@description", Description);
           
            return ExecuteNQ(MyCommand);
        }

        public bool Update()
        {
            MyCommand = CommandBuilder(@"update category set name = @name, description = @description, categoryId = @categoryId where id=@id");
            MyCommand.Parameters.AddWithValue("@id", Id);
            MyCommand.Parameters.AddWithValue("@name", Name);
            MyCommand.Parameters.AddWithValue("@description", Description);
            MyCommand.Parameters.AddWithValue("@categoryId", CategoryId);

            return ExecuteNQ(MyCommand);
        }

        public bool Delete()
        {
            MyCommand = CommandBuilder(@"delete from category where id=@id");
            MyCommand.Parameters.AddWithValue("@id", Id);
            
            return ExecuteNQ(MyCommand);
        }

        public bool SelectById()    
        {
            MyCommand = CommandBuilder(@"select id, name, description, categoryId from category where id=@id");
            MyCommand.Parameters.AddWithValue("@id", Id);

            MyReader = ExecuteReader(MyCommand);

            while (MyReader.Read())
            {
                Name = MyReader["name"].ToString();
                Description = MyReader["description"].ToString();
                CategoryId = Convert.ToInt32(MyReader["categoryId"]);
                return true;
            }
            return false;
        }

        public DataSet Select()
        {
            MyCommand = CommandBuilder("select c1.id, c1.name, c1.description, c2.name as category from category as c1 left join category as c2 on c1.categoryId = c2.id where c1.id > 0");

            if (!string.IsNullOrEmpty(Search))
            {
                MyCommand.CommandText += " and (c1.name like @search or c1.description like @search)";
                MyCommand.Parameters.AddWithValue("@search", "%" + Search + "%");
            }

            if(CategoryId > 0)
            {
                MyCommand.CommandText += " and c2.id = @categoryId";
                MyCommand.Parameters.AddWithValue("@categoryId", CategoryId);
            }

            return ExecuteDataSet(MyCommand);
        }

        public DataSet SelectMenu(int Category  = 0)
        {
            MyCommand = CommandBuilder("select id, name from category");



            if (Category > 0)
            {
                MyCommand.CommandText += " where categoryId = @categoryId";
                MyCommand.Parameters.AddWithValue("@categoryId", Category);
            }
            else
            {
                MyCommand.CommandText += " where  categoryId is null ";
            }

            return ExecuteDataSet(MyCommand);
        }

    }
}
