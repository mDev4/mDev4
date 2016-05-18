using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Shared
{
    class DatabaseHelper
    {
        public static string dbString = "Data Source=lvsdb.database.windows.net;Initial Catalog = LVSDB; Persist Security Info=True;User ID = Nick; Password=Kinderenvoorkinderen!12";

        // Connection specifics
        public static readonly string CONNECTION = "[LVSDB]";
        public static readonly string SCHEMA = "[LVS]";

        //table names
        public static readonly string GROUP_TABLE = SCHEMA + ".[Group]";
        public static readonly string USER_TABLE = SCHEMA + ".[User]";
        public static readonly string STUDENT_TABLE = SCHEMA + ".[Student]";
        public static readonly string ANNOUNCEMENT_TABLE = SCHEMA + ".[Announcement]";
        public static readonly string GROUP_STUDENT_TABLE = SCHEMA + ".[Student_Group]";
        public static readonly string TEST_TABLE = SCHEMA + ".[Test]";
        public static readonly string TEST_STUDENT_TABLE = SCHEMA + ".[Student_Test]";


        public static SqlConnection getConnection()
        {
            using (SqlConnection con = new SqlConnection(dbString))
            {
                return con;
            }
        }
    }
}
