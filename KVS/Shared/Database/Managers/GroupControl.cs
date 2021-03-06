﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Shared.Database.Models;
using System.Data.SqlClient;

namespace Shared.Database.Managers
{
    /*
     * Class for reading and writing data into the Group table of the database 
     */
    class GroupControl
    {
        /*
        * Adding a Group to the database according to given data
        */
        public static void addGroup(GroupModel group)
        {
            using (SqlConnection con = new SqlConnection(DatabaseHelper.dbString))// Using the right connection
            {
                con.Open();

                try
                {
                    // Query
                    using (SqlCommand command = new SqlCommand(
                        "INSERT INTO " + DatabaseHelper.GROUP_TABLE + " VALUES(@name, @current_academic_year, @current_year_of_study, @start_year)", con))
                    {
                        // Adding query parameters so the right data is added
                        command.Parameters.Add(new SqlParameter("name", group.Name));
                        command.Parameters.Add(new SqlParameter("current_academic_year", group.CurrCalendarYear));
                        command.Parameters.Add(new SqlParameter("current_year_of_study", group.CurrYear));
                        command.Parameters.Add(new SqlParameter("start_year", group.StartYear));

                        command.ExecuteNonQuery(); // Executing
                    }
                }
                catch (SqlException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        /*
        * Gets a group by looking at its id and returns it
        */
        public static GroupModel getGroupById(string id)
        {

            GroupModel group = new GroupModel();
            // Making sure to use the right database connection
            using (SqlConnection con = new SqlConnection(DatabaseHelper.dbString))
            {

                con.Open();

                using (SqlCommand command = new SqlCommand(
                    "SELECT * FROM " + DatabaseHelper.GROUP_TABLE + " WHERE id = @id", con)) // Query to execute
                {
                    command.Parameters.Add(new SqlParameter("id", id)); // Adding the given parameters to the query

                    SqlDataReader reader = command.ExecuteReader(); // Execute query

                    // Getting result(s) from query
                    while (reader.Read())
                    {
                        // Assigning values from the result of the query to a new GroupModel object to use in the app
                        group.Id = reader.GetInt16(0);
                        group.Name = reader.GetString(1);
                        group.CurrCalendarYear = reader.GetInt16(2);
                        group.CurrYear = reader.GetInt16(3);
                        group.StartYear = reader.GetInt16(4);

                        return group;
                    }
                }
            }
            return group;
        }
        /*
        * Gets a List of all groups that have ever existed and exist now.
        */
        public static List<GroupModel> getAllGroups()
        {
            List<GroupModel> groups = new List<GroupModel>();
            using (SqlConnection con = new SqlConnection(DatabaseHelper.dbString)) // Using the right connection
            {
                con.Open();

                using (SqlCommand command = new SqlCommand(
                    "SELECT * FROM " + DatabaseHelper.GROUP_TABLE, con)) // Query to execute
                {
                    SqlDataReader reader = command.ExecuteReader(); // Executing query

                    // Getting result(s) from query
                    while (reader.Read())
                    {
                        GroupModel group = new GroupModel();
                        // Assigning values from results to new GroupModel Object
                        group.Id = reader.GetInt16(0);
                        group.Name = reader.GetString(1);
                        group.CurrCalendarYear = reader.GetInt16(2);
                        group.CurrYear = reader.GetInt16(3);
                        group.StartYear = reader.GetInt16(4);


                        // Adding GroupModel Object to List
                        groups.Add(group);

                    }
                }
            }
            return groups; // Give back List of all Groups
        }

        /*
       * Gets a group by looking at its id and returns it
       */
        public static List<GroupModel> getGroupsByAcademicYear(string academicYear)
        {
            List<GroupModel> groups = new List<GroupModel>();

            // Making sure to use the right database connection
            using (SqlConnection con = new SqlConnection(DatabaseHelper.dbString))
            {
                con.Open();

                using (SqlCommand command = new SqlCommand(
                    "SELECT * FROM " + DatabaseHelper.GROUP_TABLE + " WHERE current_academic_year = @academicYear", con)) // Query to execute
                {
                    command.Parameters.Add(new SqlParameter("academicYear", academicYear)); // Adding the given parameters to the query

                    SqlDataReader reader = command.ExecuteReader(); // Execute query

                    // Getting result(s) from query
                    while (reader.Read())
                    {
                        GroupModel group = new GroupModel();
                        // Assigning values from the result of the query to a new GroupModel object to use in the app
                        group.Id = reader.GetInt16(0);
                        group.Name = reader.GetString(1);
                        group.CurrCalendarYear = reader.GetInt16(2);
                        group.CurrYear = reader.GetInt16(3);
                        group.StartYear = reader.GetInt16(4);

                        groups.Add(group);
                    }
                }
            }
            return groups;
        }

    }
}

