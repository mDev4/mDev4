using System;
using System.Collections;
using System.Text;
using System.Data.SqlClient;
using Shared.Database.Models;
using System.Collections.Generic;

namespace Shared.Database.Managers
{
    class StudentControl
    {
        /*
         * Class for reading and writing data into the Student table of the database 
         */

        /*
        * Adds a student to the database with given data
        */
        public static void addStudent(StudentModel student)
        {
            using (SqlConnection con = new SqlConnection(DatabaseHelper.dbString))// Using right connection
            {
                con.Open();

                try
                {
                    // Query
                    using (SqlCommand command = new SqlCommand(
                        "INSERT INTO " + DatabaseHelper.STUDENT_TABLE + " VALUES(@firstName, @lastName, @studentCode, @birthDate, @particulars, @group)", con))
                    {  
                        // Adding right data to the query
                        command.Parameters.Add(new SqlParameter("firstName", student.Firstname));
                        command.Parameters.Add(new SqlParameter("lastName", student.Lastname));
                        command.Parameters.Add(new SqlParameter("studentCode", student.Studentcode));
                        command.Parameters.Add(new SqlParameter("birthDate", student.BirthDate));
                        command.Parameters.Add(new SqlParameter("particulars", student.Particulars));
                        command.Parameters.Add(new SqlParameter("group", student.Group));

                        command.ExecuteNonQuery(); // Execute query
                    }
                }
                catch (SqlException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        /*
        * Getting a student by its name
        */
        public static StudentModel getStudentByName(string firstName, string lastName)
        {
            StudentModel student = new StudentModel();
            using (SqlConnection con = new SqlConnection(DatabaseHelper.dbString))// Using right connection
            {
                con.Open();

                // Query
                using (SqlCommand command = new SqlCommand(
                    "SELECT * FROM " + DatabaseHelper.STUDENT_TABLE + " WHERE first_name = @firstName AND last_name = @lastName", con))
                {
                    // Adding name to query to get by that name
                    command.Parameters.Add(new SqlParameter("firstName", firstName));
                    command.Parameters.Add(new SqlParameter("lastName", lastName));

                    SqlDataReader reader = command.ExecuteReader(); //execute

                    // Getting result from query
                    while (reader.Read())
                    {
                        // Converting result to StudentModel 
                        student.Id = reader.GetInt32(0);
                        student.Firstname = reader.GetString(1);
                        student.Lastname = reader.GetString(2);
                        student.Studentcode = reader.GetString(3);
                        student.BirthDate = reader.GetDateTime(4);
                        student.Particulars = reader.GetString(5);
                        student.Group = reader.GetString(6);

                        return student;
                    }
                }
            }
            return student;
        }

        /*
        * Getting a student from the database by name
        */
        public static StudentModel getStudentById(int id)
        {
            StudentModel student = new StudentModel();
            using (SqlConnection con = new SqlConnection(DatabaseHelper.dbString))// Using right connection
            {
                con.Open();

                // Query
                using (SqlCommand command = new SqlCommand(
                    "SELECT * FROM " + DatabaseHelper.STUDENT_TABLE + "WHERE id = @id", con))
                {
                    // Adding id to search with
                    command.Parameters.Add(new SqlParameter("id", id));

                    SqlDataReader reader = command.ExecuteReader(); //execute query

                    // Getting result
                    while (reader.Read())
                    {
                        // Converting result to StudentModel
                        student.Id = reader.GetInt32(0);
                        student.Firstname = reader.GetString(1);
                        student.Lastname = reader.GetString(2);
                        student.Studentcode = reader.GetString(3);
                        student.BirthDate = reader.GetDateTime(4);
                        student.Particulars = reader.GetString(5);
                        student.Group = reader.GetString(6);

                        return student;
                    }
                }
            }
            return student;
        }
    }
}
