using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data;
using Microsoft.Data.SqlClient;

namespace facturaApp.data
{
    internal class Datahelper
    {
        private static Datahelper? _instance;
        private SqlConnection _connection;

        private Datahelper()
        {
            _connection = new SqlConnection(@"Data Source=CARMEN\SQLEXPRESS;Initial Catalog=FACTURASBD;Integrated Security=True;Encrypt=False");
        }
        public static Datahelper GetInstance()
        {
            if (_instance == null)
            {
                _instance = new Datahelper();
            }
            return _instance;
        }

        public DataTable ExecuteSPQuery(string sp)
        {
            DataTable dt = new DataTable();
            try
            {

                _connection.Open();
                var cmd = new SqlCommand(sp, _connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = sp;


            

                dt.Load(cmd.ExecuteReader());
            }
            catch (SqlException ex)
            {

                throw;
            }
            finally
            {

                _connection.Close();
            }

            return dt;
        }
        public DataTable ExecuteSPQuery(string sp, List<parameters>? param)
        {
            DataTable dt = new DataTable();
            try
            {
                
                _connection.Open();
                var cmd = new SqlCommand(sp, _connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = sp;

                
                if (param != null)
                {
                    foreach (parameters p in param)
                    {
                        cmd.Parameters.AddWithValue(p.Name, p.Valor);
                    }
                }

                dt.Load(cmd.ExecuteReader());
            }
            catch (SqlException ex)
            {
                
                throw;
            }
            finally
            {
                
                _connection.Close();
            }

            return dt;
        }


        public int executeTransact(string sp, List<parameters>? param,SqlTransaction tr)
        {
            return 0;
        }

        public SqlConnection GetConnection()
        {
            return _connection;
        } 

    }
}
