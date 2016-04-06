using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Shared
{
    class DatabaseHelper
    {
        public static string dbString = "Data Source=lvsdb.database.windows.net;Initial Catalog = LVSDB; Persist Security Info=True;User ID = Nick; Password=Kinderenvoorkinderen!12";

        public static SqlConnection getConnection()
        {
            using (SqlConnection con = new SqlConnection(dbString))
            {
                return con;
            }
        }
    }
}
