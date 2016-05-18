using Shared.Database.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Shared.Database.Managers
{
    class TestControl
    {
        public static TestModel getTestById(string id)
        {
            TestModel test = new TestModel();
            using (SqlConnection con = new SqlConnection(DatabaseHelper.dbString))// Using right connection
            {
                con.Open();

                // Query
                using (SqlCommand command = new SqlCommand(
                    "SELECT * FROM " + DatabaseHelper.TEST_TABLE + "WHERE id = @id", con))
                {
                    // Adding id to search with
                    command.Parameters.Add(new SqlParameter("id", id));

                    SqlDataReader reader = command.ExecuteReader(); //execute query

                    // Getting result
                    while (reader.Read())
                    {
                        // Converting result to StudentModel
                        test.Id = reader.GetInt32(0);
                        test.Title = reader.GetString(1);
                        test.Date = DateTime.Parse(reader.GetString(2));
                        test.Subject = reader.GetString(3);

                        return test;
                    }
                }
            }
            return test;
        }
    }
}
