using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Shared.Database.Models;
using System.Data.SqlClient;

namespace Shared.Database.Managers
{
    class GroupControl
    {

        public static void addStudentToGroup(StudentModel student, GroupModel group)
        {
            using (SqlConnection con = new SqlConnection(DatabaseHelper.dbString))
            {
                con.Open();

                try
                {
                    using (SqlCommand command = new SqlCommand(
                        "INSERT INTO [Group_Student] VALUES(@group_currentCalendarYear, @group_name, @student_id)", con))
                    {
                        command.Parameters.Add(new SqlParameter("group_currentCalendarYear", group.CurrCalendarYear));
                        command.Parameters.Add(new SqlParameter("group_name", group.Name));
                        command.Parameters.Add(new SqlParameter("student_id", student.Id));

                        command.ExecuteNonQuery();
                    }
                }
                catch (SqlException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        public static GroupModel getGroupByName(string name)
        {
            GroupModel group = new GroupModel();
            using (SqlConnection con = new SqlConnection(DatabaseHelper.dbString))
            {
                con.Open();

                using (SqlCommand command = new SqlCommand(
                    "SELECT * FROM [Group] WHERE name = @name", con))
                {
                    command.Parameters.Add(new SqlParameter("name", name));

                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        group.StartYear = reader.GetDateTime(0);
                        group.Name = reader.GetString(1);
                        group.CurrCalendarYear = reader.GetDateTime(2);
                        group.CurrYear = reader.GetInt32(3);

                        return group;
                    }
                }
            }
            return group;
        }

        public static GroupModel getGroupByNameAndYear(string name, DateTime currCal)
        {
            GroupModel group = new GroupModel();
            using (SqlConnection con = new SqlConnection(DatabaseHelper.dbString))
            {
                con.Open();

                using (SqlCommand command = new SqlCommand(
                    "SELECT * FROM [Group] WHERE name = @name AND currentCalendarYear = @currentCalendarYear", con))
                {
                    command.Parameters.Add(new SqlParameter("name", name));
                    command.Parameters.Add(new SqlParameter("currentCalendarYear", currCal));

                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        group.StartYear = reader.GetDateTime(0);
                        group.Name = reader.GetString(1);
                        group.CurrCalendarYear = reader.GetDateTime(2);
                        group.CurrYear = reader.GetInt32(3);

                        return group;
                    }
                }
            }
            return group;
        }
    }

}

