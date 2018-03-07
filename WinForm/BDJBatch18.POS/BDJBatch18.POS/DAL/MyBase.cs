using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class MyBase
    {
        protected string _error;
        public string Error
        {
            get
            {
                return _error;
            }
        }

        public string Search { get; set; }
        public bool isDateSearch { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public double AmountFrom { get; set; }
        public double AmountTo { get; set; }
        public int lastId { get; set; }

        protected SqlConnection CN = new SqlConnection("Data Source = .; Initial Catalog = dbBDJ18pos; Integrated Security = True");

        private bool Connection()
        {
            if (MyReader != null && !MyReader.IsClosed)
                MyReader.Close();

            if (CN.State == ConnectionState.Open)
                return true;

            try
            {
                CN.Open();
                return true;
            }
            catch (Exception ex)
            {
                _error = ex.Message;
            }
            return false;
        }

        protected bool ExecuteNQ(SqlCommand cmd)
        {
            if (!Connection())
                return false;
            try
            {
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                _error = ex.Message;
            }
            return false;
        }

        protected bool ExecuteScaler(SqlCommand cmd)
        {
            if (!Connection())
                return false;
            try
            {
                lastId = Convert.ToInt32( cmd.ExecuteScalar());
                return true;
            }
            catch (Exception ex)
            {
                _error = ex.Message;
            }
            return false;
        }

        protected SqlCommand MyCommand { get; set; }
        protected SqlCommand CommandBuilder(string sql)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = CN;
            cmd.CommandText = sql;
            return cmd;
        }

        protected SqlDataReader MyReader { get; set; }
        protected SqlDataReader ExecuteReader(SqlCommand cmd)
        {
            if (!Connection())
                return null;
                return cmd.ExecuteReader();
        }

        protected DataSet ExecuteDataSet(string sql)
        {
            if (!Connection())
                return null;

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = CN;
            cmd.CommandText = sql;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);

            return ds;
        }

        protected DataSet ExecuteDataSet(SqlCommand cmd)
        {
            if (!Connection())
                return null;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);

            return ds;
        }

    }



}
