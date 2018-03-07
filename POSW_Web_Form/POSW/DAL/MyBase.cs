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

        public bool IsDateSearch { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }

        public double AmmountFrom { get; set; }
        public double AmmountTo { get; set; }

        public int LastId { get; set; }

        public List<SqlCommand> TransactionCommands { get; set; }

        public bool ExecuteTransaction()
        {
            if (!Connection())
                return false;

            SqlTransaction transaction = CN.BeginTransaction();

            try
            {
                foreach (SqlCommand cmd in TransactionCommands)
                {
                    cmd.Transaction = transaction;
                    cmd.ExecuteNonQuery();
                }
                transaction.Commit();
                return true;
            }
            catch(Exception ex)
            {
                transaction.Rollback();
                _error = ex.Message;
            }

            

                return false;
        }


        protected SqlConnection CN = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["MyCon"].ConnectionString);

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
                LastId = Convert.ToInt32(cmd.ExecuteScalar());
                return true;
            }
            catch (Exception ex)
            {
                _error = ex.Message;
            }
            return false;
        }

        public SqlCommand MyCommand { get; set; }
        public SqlCommand CommandBuilder(string sql)
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
