using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TZMDotNetCore.RestApi.Db  
{
    internal static class ConnectionStrings
    {
        public static SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder()
        {
            DataSource = "LENOVO-V14\\SQLEXPRESS",
            InitialCatalog = "TZMDotNetCore",
            UserID = "sa",
            Password = "sasa@123",
            TrustServerCertificate = true
        };

        public static object SqlconnectionStringBuilder { get; internal set; }

        //public static object SqlConnectionStringBuilder { get; internal set; }
    }
}
