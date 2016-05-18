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
                        // Converting result to TestModels
                        test.Id = reader.GetInt32(0);
                        test.Date = DateTime.Parse(reader.GetString(1));
                        test.Title = reader.GetString(2);                        
                        test.Description = reader.GetString(3);

                        return test;
                    }
                }
            }
            return test;
        }

        public static List<TestModel> getAllTests()
        {
            List<TestModel> tests = new List<TestModel>();
            using (SqlConnection con = new SqlConnection(DatabaseHelper.dbString)) // Using the right connection
            {
                con.Open();

                using (SqlCommand command = new SqlCommand(
                    "SELECT * FROM " + DatabaseHelper.TEST_TABLE, con)) // Query to execute
                {
                    SqlDataReader reader = command.ExecuteReader(); // Executing query

                    // Getting result(s) from query
                    while (reader.Read())
                    {
                        TestModel test = new TestModel();
                        // Assigning values from results to new TestModel Object
                        test.Id = reader.GetInt16(0);
                        test.Date = DateTime.Parse(reader.GetString(1));
                        test.Title = reader.GetString(2);                        
                        test.Description = reader.GetString(3);

                        Console.WriteLine(test.Title);

                        // Adding TestModel Object to List
                        tests.Add(test);

                    }
                }
            }
            return tests; // Give back List of all Tests
        }
    }
}
