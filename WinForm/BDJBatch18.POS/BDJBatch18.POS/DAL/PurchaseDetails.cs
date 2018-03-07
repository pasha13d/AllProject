using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    class PurchaseDetails : MyBase
    {
        public int PurchaseId { get; set; }
        public int ProductId { get; set; }
        public int Qty { get; set; }

        public double Rate { get; set; }

        public bool insert()
        {
            MyCommand = CommandBuilder(@"insert into purchaseDetails (purchaseId, productId, qty, rate) values(@purchaseId, @productId, @qty, @rate)");
            MyCommand.Parameters.AddWithValue("@purchaseId", PurchaseId);
            MyCommand.Parameters.AddWithValue("@productId", ProductId);
            MyCommand.Parameters.AddWithValue("@qty", Qty);
            MyCommand.Parameters.AddWithValue("@rate", Rate);
            return ExecuteNQ(MyCommand);
        }
        public bool update()
        {
            MyCommand = CommandBuilder(@"update purchaseDetails set purchaseId = @purchaseId, productId = @productId, qty = @qty, rate = @rate where puchaseId = @puchaseId and productId= @productId ");
            MyCommand.Parameters.AddWithValue("@purchaseId", PurchaseId);
            MyCommand.Parameters.AddWithValue("@productId", ProductId);
            MyCommand.Parameters.AddWithValue("@qty", Qty);
            MyCommand.Parameters.AddWithValue("@rate", Rate);
            return ExecuteNQ(MyCommand);
        }

        public bool delete()
        {
            MyCommand = CommandBuilder(@"delete from purchaseDetails where puchaseId = @puchaseId and productId= @productId");
            MyCommand.Parameters.AddWithValue("@purchaseId", PurchaseId);
            MyCommand.Parameters.AddWithValue("@productId", ProductId);
            return ExecuteNQ(MyCommand);
        }
        public bool selectById()
        {
            MyCommand = CommandBuilder(@"select purchaseId, productId, qty, rate from purchaseDetails where puchaseId = @puchaseId and productId= @productId");
            MyCommand.Parameters.AddWithValue("@purchaseId", PurchaseId);
            MyCommand.Parameters.AddWithValue("@productId", ProductId);
            MyReader = ExecuteReader(MyCommand);
            while (MyReader.Read())
            {
                PurchaseId = Convert.ToInt32(MyReader["purchaseId"]);
                ProductId = Convert.ToInt32(MyReader["productId"]);
                Qty = Convert.ToInt32(MyReader["qty"]);
                Rate = Convert.ToDouble( MyReader["rate"].ToString());
                return true;
            }
            return false;

        }

        public DataSet select()
        {
            MyCommand = CommandBuilder(@"select pd.purchaseId, pd.productId, prc.number, p.name as product, qty, rate from purchaseDetails as pd left join product as p on pd.productId = p.id left join purchase as prc on pd.purchaseId = prc.id");
            return ExecuteDataSet(MyCommand);
        }
    }
}
