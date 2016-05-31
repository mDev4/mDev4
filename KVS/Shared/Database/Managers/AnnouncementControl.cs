using Shared.Database.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;


namespace Shared.Database.Managers
{
    /*
     * Class for reading and writing data into the Announcements table of the database 
     * NOT UPDATED FOR NICK'S NEW NAMES
     */
    class AnnouncementControl
    {

        public static List<AnnouncementModel> getAllAnn()
        {
            List<AnnouncementModel> announcements = new List<AnnouncementModel>();
            using (SqlConnection con = new SqlConnection(DatabaseHelper.dbString)) // Using the right connection
            {
                con.Open();

                using (SqlCommand command = new SqlCommand(
                    "SELECT * FROM " + DatabaseHelper.ANNOUNCEMENT_TABLE, con)) // Query to execute
                {
                    SqlDataReader reader = command.ExecuteReader(); // Executing query

                    // Getting result(s) from query
                    while (reader.Read())
                    {
                        AnnouncementModel ann = new AnnouncementModel();
                        // Assigning values from results to new TestModel Object
                        ann.Id = reader.GetInt16(0);
                        ann.Message = reader.GetString(1);
                        ann.Author = reader.GetInt16(2);
                        ann.Title = reader.GetString(3);
                        ann.Type = reader.GetString(4);

                        Console.WriteLine(ann.Title);

                        // Adding TestModel Object to List
                        announcements.Add(ann);

                    }
                }
            }
            return announcements; // Give back List of all Tests
        }
    }
}
