using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace DAL
{
    public class ProductPrice : MyBase
    {
        public int  ProductId { get; set; }
        public int UnitId { get; set; }
        public double Price { get; set; }

        public bool Insert()
        {
            MyCommand = CommandBuilder(@"insert into productPrice(productId, unitId, price) values(@productId, @unitId, @price)");
            MyCommand.Parameters.AddWithValue("@productId", ProductId);
            MyCommand.Parameters.AddWithValue("@unitId", UnitId);
            MyCommand.Parameters.AddWithValue("@price", Price);

            return ExecuteNQ(MyCommand);
        }

        public bool Update()
        {
            MyCommand = CommandBuilder(@"update productPrice set productId = @productId, unitId = @unitId, price = @price where productId = @productId and unitId = @unitId");
            MyCommand.Parameters.AddWithValue("@productId", ProductId);
            MyCommand.Parameters.AddWithValue("@unitId", UnitId);
            MyCommand.Parameters.AddWithValue("@price", Price);

            return ExecuteNQ(MyCommand);
        }

        public bool Delete()
        {
            MyCommand = CommandBuilder(@"delete from productPrice where productId = @productId and unitId = @unitId");
            MyCommand.Parameters.AddWithValue("@productId", ProductId);
            MyCommand.Parameters.AddWithValue("@unitId", UnitId);

            return ExecuteNQ(MyCommand);
        }

        public bool SelectById()
        {
            MyCommand =
                CommandBuilder(
                    @"select productId, unitId, price from productPrice where productId = @productId and unitId = @unitId");
            MyCommand.Parameters.AddWithValue("@productId", ProductId);
            MyCommand.Parameters.AddWithValue("@unitId", UnitId);

            MyReader = ExecuteReader(MyCommand);

            while (MyReader.Read())
            {
                Price = Convert.ToDouble(MyReader["price"].ToString());
                return true;
            }
            return false;
        }

        public DataSet Select()
        {
            MyCommand = CommandBuilder(@"select pp.productId, pp.unitId, p.name as product, u.name as unit, pp.price from 
                                         productPrice as pp left join product as p on pp.productId = p.Id  
                                         left join unit as u on pp.unitId = u.id and where p.id > 0 ");

            //if (!string.IsNullOrEmpty(Search))
            //{
            //    MyCommand.CommandText += " and pp.price like @search";
            //    MyCommand.Parameters.AddWithValue("@search", "%" + Search + "%");
            //}
            if (ProductId > 0)
            {
                MyCommand.CommandText += " and p.id = @productId";
                MyCommand.Parameters.AddWithValue("@productId", ProductId);
            }
            if (UnitId > 0)
            {
                MyCommand.CommandText += " and u.id = @unitId";
                MyCommand.Parameters.AddWithValue("@unitId", UnitId);
            }
            return ExecuteDataSet(MyCommand);

        }

    }
}
