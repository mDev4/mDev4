using Shared.Database.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Shared.Database.Managers
{
    /*
     * Class for reading and writing data into the Group_Student table of the database 
     * NOT UPDATED FOR NICK'S NEW NAMES
     */
    class GroupStudentControl
    {

        public static List<StudentModel> getStudentsByGroup(string groupId)
        {

            List<StudentModel> students = new List<StudentModel>();
            // Making sure to use the right database connection
            using (SqlConnection con = new SqlConnection(DatabaseHelper.dbString))
            {
                con.Open();

                using (SqlCommand command = new SqlCommand(
                    "SELECT * FROM " + DatabaseHelper.STUDENT_TABLE + " s INNER JOIN " + DatabaseHelper.GROUP_STUDENT_TABLE + " gs ON s.id = gs.student_id WHERE gs.group_id = @groupId "
                    , con)) // Query to execute
                {
                    command.Parameters.Add(new SqlParameter("groupId", groupId)); // Adding the given parameters to the query

                    SqlDataReader reader = command.ExecuteReader(); // Execute query

                    // Getting result(s) from query
                    while (reader.Read())
                    {
                        StudentModel student = new StudentModel();
                        // Assigning values from the result of the query to a new GroupModel object to use in the app
                        student.Id = reader.GetInt32(0);
                        student.Studentcode = reader.GetString(1);
                        student.Particulars = reader.GetString(2);
                        student.BirthDate = DateTime.Parse(reader.GetString(3));
                        student.Firstname = reader.GetString(4);
                        student.Middlename = reader.GetString(5);
                        student.Lastname = reader.GetString(6);
                        student.StartYear = reader.GetInt16(7);

                        students.Add(student);
                    }
                }
            }
            return students;
        }

        public static void addStudentToGroup(StudentModel student, GroupModel group)
        {
            using (SqlConnection con = new SqlConnection(DatabaseHelper.dbString))// Using right connection
            {
                con.Open();

                try
                {
                    // Query
                    using (SqlCommand command = new SqlCommand(
                        "INSERT INTO " + DatabaseHelper.GROUP_STUDENT_TABLE + " VALUES(@groupId, @studentId)", con))
                    {
                        // Adding right data to the query
                        command.Parameters.Add(new SqlParameter("groupId", group.Id));
                        command.Parameters.Add(new SqlParameter("studentId", student.Id));
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
