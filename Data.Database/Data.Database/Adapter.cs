using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;

namespace Data.Database
{
    public class Adapter
    {


        const string consKeyDefaultCnnString = "ConnStringServerDamianNetbook";

        private SqlConnection _sqlConn;

        public SqlConnection SqlConn
        {
            set {
                _sqlConn = value;    
                }
            get {
                return _sqlConn;
                }
        }

        protected void OpenConnection()
        {
            string config = ConfigurationManager.ConnectionStrings[consKeyDefaultCnnString].ConnectionString;

            SqlConn = new SqlConnection(config);
            SqlConn.Open();
        }

        protected void CloseConnection()
        {
            SqlConn.Close();
            SqlConn = null;
        }

        protected SqlDataReader ExecuteReader(String commandText)
        {
            throw new Exception("Metodo no implementado");
        }
    }
}
