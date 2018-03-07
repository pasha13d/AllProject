using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    class Purchase : MyBase
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public DateTime DateTime { get; set; }
        public int LedgerId { get; set; }
        public int EmployeeId { get; set;}
        public double Total { get; set; }
        public double Vat { get; set; }
        public double Discount { get; set; }

        public bool insert()
        {
            MyCommand = CommandBuilder(@"insert into purchase (number, ledgerId, employeeId, total, vat, discount) values(@number, @ledgerId, @employeeId, @total, @vat, @discount) select @@identity");
            MyCommand.Parameters.AddWithValue("@number", Number);
            MyCommand.Parameters.AddWithValue("@ledgerId", LedgerId);
            MyCommand.Parameters.AddWithValue("@employeeId", EmployeeId);
            MyCommand.Parameters.AddWithValue("@total", Total);
            MyCommand.Parameters.AddWithValue("@vat", Vat);
            MyCommand.Parameters.AddWithValue("@discount", Discount);
            return ExecuteScaler(MyCommand);
        }

        public void insertCommand()
        {
            MyCommand = CommandBuilder(@"insert into purchase (number, ledgerId, employeeId, total, vat, discount) values(@number, @ledgerId, @employeeId, @total, @vat, @discount)");
            MyCommand.Parameters.AddWithValue("@number", Number);
            MyCommand.Parameters.AddWithValue("@ledgerId", LedgerId);
            MyCommand.Parameters.AddWithValue("@employeeId", EmployeeId);
            MyCommand.Parameters.AddWithValue("@total", Total);
            MyCommand.Parameters.AddWithValue("@vat", Vat);
            MyCommand.Parameters.AddWithValue("@discount", Discount);
        }

        public bool update()
        {
            MyCommand = CommandBuilder(@"update purchase set number = @number, ledgerId = @ledgerId, employeeId =@employeeId, 
                                        total = @total, vat = @vat, discount = @discount where id = @id");
            MyCommand.Parameters.AddWithValue("@id", Id);
            MyCommand.Parameters.AddWithValue("@number", Number);
            MyCommand.Parameters.AddWithValue("@ledgerId", LedgerId);
            MyCommand.Parameters.AddWithValue("@employeeId", EmployeeId);
            MyCommand.Parameters.AddWithValue("@total", Total);
            MyCommand.Parameters.AddWithValue("@vat", Vat);
            MyCommand.Parameters.AddWithValue("@discount", Discount);
            return ExecuteNQ(MyCommand);
        }

        public bool delete(string ids="")
        {
            if (ids != null)
            {
                MyCommand = CommandBuilder(@"delete form purchase where id in " + ids + "");
            }
            else
            {
                MyCommand = CommandBuilder("delete from purchase where id = @id");
                MyCommand.Parameters.AddWithValue("@id", Id);
            }
            return ExecuteNQ(MyCommand);
        }
        public bool selectById()
        {
            MyCommand = CommandBuilder(@"select id, number, ledgerId, employeeId, total, vat, discount from purchase where id = @id");
            MyCommand.Parameters.AddWithValue("@id", Id);

            MyReader = ExecuteReader(MyCommand);
            while (MyReader.Read())
            {
                Number = MyReader["number"].ToString();
                LedgerId = Convert.ToInt32(MyReader["ledgerId"]);
                EmployeeId = Convert.ToInt32(MyReader["employeeId"]);
                Total = Convert.ToDouble(MyReader["total"]);
                Vat = Convert.ToDouble(MyReader["vat"]);
                Discount = Convert.ToDouble(MyReader["discount"]);
                return true;
            }
            return false;
        }
        public DataSet select()
        {
            MyCommand = CommandBuilder(@"select pr.number, lg.name as Ledger, em.name as Employee, pr,total, pr.vat, pr.discount 
                                        from purchase as pr 
                                        left join ledger as lg on pr.ledgerId = lg.id
                                        left join employee as em on pr.employeeId = em.id where pr.id > 0");
            if (!string.IsNullOrEmpty(Search))
            {
                MyCommand.CommandText += " and (pr.number like @search or pr.vat like @search or pr.discout like @search";
                MyCommand.Parameters.AddWithValue("@search", "%" + Search + "%");
            }
            if(LedgerId > 0)
            {
                MyCommand.CommandText += " and lg.id = @ledgerId";
                MyCommand.Parameters.AddWithValue("@ledgerId", LedgerId);
            }
            if(EmployeeId > 0)
            {
                MyCommand.CommandText += " and  em.id = @employeeId";
                MyCommand.Parameters.AddWithValue("@employeeId", EmployeeId);
            }

            return ExecuteDataSet(MyCommand);
        }
    }
}
