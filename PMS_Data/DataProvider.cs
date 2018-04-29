using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace PMS_Data
{
    public class DataProvider
    {
        private static SqlConnection _connection;   //1 connection duy nhất
        private static SqlDataAdapter _adapter = new SqlDataAdapter();     //1 adapter duy nhất

        public static void OpenConnection ()
        {
            try
            {
                string strConnectionString = ConfigurationManager.ConnectionStrings["PMSconnectionString"].ToString();
                _connection = new SqlConnection(strConnectionString);
                _connection.Open();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void CloseConnection()
        {
            try
            {
                if (_connection.State != System.Data.ConnectionState.Closed) _connection.Close();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static DataTable ExecQuery (string sql)
        {
            try
            {
                if (_connection == null) OpenConnection();
                SqlCommand cmd = new SqlCommand(sql, _connection);
                _adapter.SelectCommand = cmd;
                DataTable dt = new DataTable();
                _adapter.Fill(dt);
                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static DataTable ExecQueryStore(string storeName)
        {
            if (storeName == null || storeName.Trim() == "") return null;
            try
            {
                if (_connection == null) OpenConnection();
                SqlCommand cmd = new SqlCommand(storeName, _connection);
                cmd.CommandType = CommandType.StoredProcedure;
                _adapter.SelectCommand = cmd;
                DataTable dt = new DataTable();
                _adapter.Fill(dt);
                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static DataTable ExecQueryStore(string storeName, SqlParameter parameter)
        {
            try
            {
                if (_connection == null) OpenConnection();
                SqlCommand cmd = new SqlCommand(storeName, _connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(parameter);
                _adapter.SelectCommand = cmd;
                DataTable dt = new DataTable();
                _adapter.Fill(dt);
                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static DataTable ExecQueryStore(string storeName, List<SqlParameter> lstParameter)
        {
            try
            {
                if (_connection == null) OpenConnection();
                SqlCommand cmd = new SqlCommand(storeName, _connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddRange(lstParameter.ToArray());
                //for (int i = 0; i < lstParameter.Count; i++)
                //{
                //    cmd.Parameters.AddWithValue(lstParameter[i].ToString(), lstParameter[i].Value.ToString());
                    
                //}
                _adapter.SelectCommand = cmd;
                DataTable dt = new DataTable();
                _adapter.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void ExecNonQuery(string sql)
        {
            try
            {
                if (_connection == null) OpenConnection();
                SqlCommand cmd = new SqlCommand(sql, _connection);
                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static void ExecNonQueryStore(string storeName)
        {
            try
            {
                if (_connection == null) OpenConnection();
                SqlCommand cmd = new SqlCommand(storeName, _connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static void ExecNonQueryStore(string storeName, List<SqlParameter> lstParameter)
        {
            try
            {
                if (_connection == null) OpenConnection();
                SqlCommand cmd = new SqlCommand(storeName, _connection);
                cmd.CommandType = CommandType.StoredProcedure;
                for (int i = 0; i < lstParameter.Count; i++)
                {
                    cmd.Parameters.AddWithValue(lstParameter[i].ToString(), lstParameter[i].Value == null ? null : lstParameter[i].Value.ToString());
                }
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
