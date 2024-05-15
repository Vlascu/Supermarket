using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace SupermarketManager.Model.DataAccessLayer
{
    public static class DALUtil
    {
        private static readonly string connectionString = ConfigurationManager.ConnectionStrings["ConnString"].ConnectionString;

        public static SqlConnection Connection
        {
            get
            {
                return new SqlConnection(connectionString);
            }
        }
    }
}
