using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace QUANLYNHANSU.DAL
{
    public class DBConnection
    {
        protected SqlConnection conn;

        public DBConnection()
        {
            string connStr = ConfigurationManager.ConnectionStrings["QLNhanSuDBConnectionString"].ConnectionString;
            conn = new SqlConnection(connStr);
        }
      
    }
}
