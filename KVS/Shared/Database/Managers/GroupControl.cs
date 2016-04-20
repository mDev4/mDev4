using System;
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
                        group.StartYear = DateTime.Parse(reader.GetString(0));
                        group.Name = reader.GetString(1);
                        group.CurrCalendarYear = DateTime.Parse(reader.GetString(2));
                        group.CurrYear = reader.GetInt32(3);
                        group.Id = reader.GetInt32(4);

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
                        // Assigning values from results to new GroupModel Object
                        GroupModel group = new GroupModel();
                        group.StartYear = DateTime.Parse(reader.GetString(0));
                        group.Name = reader.GetString(1);
                        group.CurrCalendarYear = DateTime.Parse(reader.GetString(2));
                        group.CurrYear = reader.GetInt32(3);

                        // Adding GroupModel Object to List
                        groups.Add(group);

                    }
                }
            }
            return groups; // Give back List of all Groups
        }

    }
}

