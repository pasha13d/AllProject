using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    class Transaction:MyBase
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public string Reference { get; set; }
        public DateTime DateTime { get; set; }
        public int LedgerId { get; set; }
        public int EmployeeId { get; set; }
        public double Debit { get; set; }
        public double Credit { get; set; }
        public string Remarks { get; set; }

        public bool Insert()
        {
            MyCommand = CommandBuilder(@"insert into transaction(number, reference, dateTime, ledgerId, employeeId, debit, credit, remarks)
             values(@number, @reference, @dateTime, @ledgerId, @employeeId, @debit, @credit, @remarks)");
            MyCommand.Parameters.AddWithValue("@number", Number);
            MyCommand.Parameters.AddWithValue("@reference", Reference);
            MyCommand.Parameters.AddWithValue("@dateTime", DateTime);
            MyCommand.Parameters.AddWithValue("@ledgerId", LedgerId);
            MyCommand.Parameters.AddWithValue("@employeeId", EmployeeId);
            MyCommand.Parameters.AddWithValue("@debit", Debit);
            MyCommand.Parameters.AddWithValue("@credit", Credit);
            MyCommand.Parameters.AddWithValue("@remarks", Remarks);
            return ExecuteNQ(MyCommand);
        }
        public bool Update()
        {
            MyCommand = CommandBuilder(@"Update transaction set number=@number,reference=@reference,dateTime=@dateTime,ledgerId=@ledgerId,employeeId=@employeeId,
              debit=@debit,credit=@credit,remarks = @remarks where id = @id)");
            MyCommand.Parameters.AddWithValue("@id", Id);
            MyCommand.Parameters.AddWithValue("@number", Number);
            MyCommand.Parameters.AddWithValue("@reference", Reference);
            MyCommand.Parameters.AddWithValue("@dateTime", DateTime);
            MyCommand.Parameters.AddWithValue("@ledgerId", LedgerId);
            MyCommand.Parameters.AddWithValue("@employeeId", EmployeeId);
            MyCommand.Parameters.AddWithValue("@debit", Debit);
            MyCommand.Parameters.AddWithValue("@credit", Credit);
            MyCommand.Parameters.AddWithValue("@remarks", Remarks);
            return ExecuteNQ(MyCommand);
        }
        public bool Delete()
        {
            MyCommand = CommandBuilder(@"Delete from transaction where id = @id)");
            MyCommand.Parameters.AddWithValue("@id",Id);
          
            return ExecuteNQ(MyCommand);
        }
        public bool SelectbyId()
        {
            MyCommand = CommandBuilder(@"Select id, number, reference, dateTime, ledgerId, employeeId, debit, credit, remarks from transaction where id=@id)");
            MyCommand.Parameters.AddWithValue("@id", Id);

            MyReader = ExecuteReader(MyCommand);

            while(MyReader.Read())
            {
                Number = Convert.ToInt32( MyReader["number"].ToString());
                Reference = MyReader["reference"].ToString();
                DateTime = (DateTime) MyReader["DateTime"];
                LedgerId = Convert.ToInt32(MyReader["ledgerId"]);
                EmployeeId = Convert.ToInt32(MyReader["employeeId"]);
                Debit = Convert.ToDouble(MyReader["debit"]);
                Credit = Convert.ToDouble(MyReader["credit"]);
                Remarks = MyReader["remarks"].ToString();
                return true;
            }
            return false;
        }
        public DataSet Select()
        {
            MyCommand = CommandBuilder(@"select  ts.id, ts.number, ts.reference, ts.dateTime, ts.debit, ts.credit,
                                    l.name as ledger, e.name as employee
                                    from [transaction] as ts
                                    left join ledger as l on ts.ledgerId=l.id
                                    left join employee as e on ts.employeeId=e.id where ts.id>0 ");
            if (!string.IsNullOrEmpty(Search))
            {
                MyCommand.CommandText += " and (ts.number like @search or ts.reference like @search or ts.remarks like @search)";
                MyCommand.Parameters.AddWithValue("@search", "%" + Search + "%");
            }
            if (LedgerId > 0)
            {
                MyCommand.CommandText += " and l.id = @ledgerId";
                MyCommand.Parameters.AddWithValue("@ledgerId", LedgerId);
            }
            if (EmployeeId > 0)
            {
                MyCommand.CommandText += " and e.id = @employeeId";
                MyCommand.Parameters.AddWithValue("@employeeId", EmployeeId);
            }
            return ExecuteDataSet(MyCommand);
        }


    }
}
