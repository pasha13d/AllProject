using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    class Product : MyBase
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public int BrandId { get; set; }
        public int CategoryId { get; set; }
        public DateTime CreateDate { get; set; }
        public double Price { get; set; }

        public bool insert()
        {
            MyCommand = CommandBuilder(@"insert into product (name, code, description, brandId, categoryId, createDate, price) values (@name, @code, @description, @brandId, @categoryId, @createDate, @price)");
            MyCommand.Parameters.AddWithValue("@name", Name);
            MyCommand.Parameters.AddWithValue("@code", Code);
            MyCommand.Parameters.AddWithValue("@description", Description);
            MyCommand.Parameters.AddWithValue("@brandId", BrandId);
            MyCommand.Parameters.AddWithValue("@categoryId", CategoryId);
            MyCommand.Parameters.AddWithValue("@createDate", CreateDate);
            MyCommand.Parameters.AddWithValue("@price", Price);

            return ExecuteNQ(MyCommand);
        }

        public bool update()
        {
            MyCommand = CommandBuilder(@"update product set name = @name, code = @code, description = @description, brandId = @brandId, categoryId = @categoryId, createDate = @createDate, price = @price where id = @id");
            MyCommand.Parameters.AddWithValue("@id", Id);
            MyCommand.Parameters.AddWithValue("@name", Name);
            MyCommand.Parameters.AddWithValue("@code", Code);
            MyCommand.Parameters.AddWithValue("@description", Description);
            MyCommand.Parameters.AddWithValue("@brandId", BrandId);
            MyCommand.Parameters.AddWithValue("@categoryId", CategoryId);
            MyCommand.Parameters.AddWithValue("@createDate", CreateDate);
            MyCommand.Parameters.AddWithValue("@price", Price);
            return ExecuteNQ(MyCommand);
        }

        public bool delete( string ids ="")
        {
            if (ids != "")
            {
                MyCommand = CommandBuilder(@"delete from product where id in " + ids + "");
            }
            else
            {
                MyCommand = CommandBuilder("delete from product where id = @id");
                MyCommand.Parameters.AddWithValue("@id", Id);
            }
            return ExecuteNQ(MyCommand);
        }

        public bool selectById()
        {
            MyCommand = CommandBuilder(@"select id, name, code, description, brandId, categoryId, createDate, price from product where id = @id");
            MyCommand.Parameters.AddWithValue("@id", Id);
            MyReader = ExecuteReader(MyCommand);

            while (MyReader.Read())
            {
                Name = MyReader["name"].ToString();
                Code = MyReader["code"].ToString();
                Description = MyReader["description"].ToString();
                BrandId = Convert.ToInt32(MyReader["brandId"]);
                CategoryId = Convert.ToInt32(MyReader["categoryId"]);
                CreateDate = Convert.ToDateTime(MyReader["createDate"]);
                Price = Convert.ToDouble(MyReader["price"]);
                return true;
            }
            return false;
        }

        public DataSet select()
        {
            MyCommand = CommandBuilder(@"select pro.id, pro.name, pro.code, pro.description, brnd.name as brand, cat.name as category, pro.createDate, pro.price from product as pro 
                                       left join brand as brnd on pro.brandId = brnd.id
                                       left join category as cat on pro.categoryId = cat.id where pro.id >0");
            if (!string.IsNullOrEmpty(Search))
            {
                MyCommand.CommandText += " and ( pro.name like @search or pro.code like @search)";
                MyCommand.Parameters.AddWithValue("@search", "%"+Search+"%");
            }
            if(BrandId > 0)
            {
                MyCommand.CommandText += " and brnd.id = @brandId";
                MyCommand.Parameters.AddWithValue("@brandId", BrandId);
            }
            if(CategoryId > 0)
            {
                MyCommand.CommandText += " and cat.id = @categoryId";
                MyCommand.Parameters.AddWithValue("@categoryId", CategoryId);
            }

            //dateSearch Condition
            if(isDateSearch)
            {
                MyCommand.CommandText += (" and pro.createDate between @date1 and @date2");
                MyCommand.Parameters.AddWithValue("@date1",DateFrom);
                MyCommand.Parameters.AddWithValue("@date2", DateTo);
            }

            return ExecuteDataSet(MyCommand);
        }
    }
}
