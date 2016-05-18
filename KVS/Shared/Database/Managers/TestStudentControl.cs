using Shared.Database.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Shared.Database.Managers
{
    class TestStudentControl
    {
        public static List<TestModel> getTestsByStudent(StudentModel student)
        {
            List<TestModel> tests = new List<TestModel>();
            TestModel test = new TestModel();
            using (SqlConnection con = new SqlConnection(DatabaseHelper.dbString))// Using right connection
            {
                con.Open();

                // Query
                using (SqlCommand command = new SqlCommand(
                    "SELECT * FROM " + DatabaseHelper.TEST_STUDENT_TABLE +  " ts INNER JOIN " + 
                    DatabaseHelper.STUDENT_TABLE + " s ON ts.student_id = s.id "+ "WHERE s.id = @id", con))
                {
                    // Adding id to search with
                    command.Parameters.Add(new SqlParameter("id", student.Id));

                    SqlDataReader reader = command.ExecuteReader(); //execute query

                    // Getting result
                    while (reader.Read())
                    {
                        // Converting result to StudentModel
                        test.Id = reader.GetInt32(0);
                        test.Title = reader.GetString(1);
                        test.Date = DateTime.Parse(reader.GetString(2));
                        test.Subject = reader.GetString(3);

                         tests.Add(test);
                    }
                }
            }
            return tests;
        }
    }
}

