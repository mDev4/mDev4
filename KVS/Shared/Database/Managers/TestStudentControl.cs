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
                    "SELECT * FROM " + DatabaseHelper.TEST_TABLE +  " t INNER JOIN " + 
                    DatabaseHelper.TEST_STUDENT_TABLE + " ts ON ts.test_id = t.id "+ "WHERE ts.student_id = @id", con))
                {
                    // Adding id to search with
                    command.Parameters.Add(new SqlParameter("id", student.Id));

                    SqlDataReader reader = command.ExecuteReader(); //execute query

                    // Getting result
                    while (reader.Read())
                    {
                        // Converting result to StudentModel
                        test.Id = reader.GetInt16(0);
                        test.Date = DateTime.Parse(reader.GetString(1));
                        test.Title = reader.GetString(2);                        
                        test.Description = reader.GetString(3);

                         tests.Add(test);
                    }
                }
            }
            return tests;
        }

        public static TestStudentModel getResultById(StudentModel student, TestModel test)
        {
            TestStudentModel result = new TestStudentModel();
            using (SqlConnection con = new SqlConnection(DatabaseHelper.dbString))// Using right connection
            {
                con.Open();

                // Query
                using (SqlCommand command = new SqlCommand(
                    "SELECT * FROM " + DatabaseHelper.TEST_STUDENT_TABLE + " WHERE test_id = @testId AND student_id = @studentId", con))
                {
                    // Adding id to search with
                    command.Parameters.Add(new SqlParameter("testId", test.Id));
                    command.Parameters.Add(new SqlParameter("studentId", student.Id));                    

                    SqlDataReader reader = command.ExecuteReader(); //execute query

                    // Getting result
                    while (reader.Read())
                    {
                        // Converting result to TestStudentModel
                        result.Student_id = reader.GetInt16(0);
                        result.Test_id = reader.GetInt32(1);
                        result.Grade = reader.GetString(2);

                        return result;
                    }
                }
            }
            return result;
        }

        public static void addStudentToTest(StudentModel student, TestModel test, string grade) {
            using (SqlConnection con = new SqlConnection(DatabaseHelper.dbString))// Using right connection
            {
                con.Open();

                try
                {
                    // Query
                    using (SqlCommand command = new SqlCommand(
                        "INSERT INTO " + DatabaseHelper.TEST_STUDENT_TABLE + " VALUES(@testId, @studentId, @grade)", con))
                    {
                        // Adding right data to the query
                        command.Parameters.Add(new SqlParameter("testId", test.Id));
                        command.Parameters.Add(new SqlParameter("studentId", student.Id));
                        command.Parameters.Add(new SqlParameter("grade", grade));
                        command.ExecuteNonQuery(); // Execute query
                    }
                }
                catch (SqlException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}

