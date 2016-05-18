using Shared.Database.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace Shared.Database.Managers
{
    /*
     * Class for reading and writing data into the User table of the database 
     */
    class UserControl
    {
        /*
        * Adding a User to the database according to given data
        */
        public static void addUser(UserModel user)
        {
            using (SqlConnection con = new SqlConnection(DatabaseHelper.dbString))// Using the right connection
            {
                con.Open();

                try
                {
                    // Query
                    using (SqlCommand command = new SqlCommand(
                        "INSERT INTO " + DatabaseHelper.USER_TABLE + " VALUES(@username, @password, @firstname, @lastname, @email, @phoneNumber)", con))
                    {
                        // Adding query parameters so the right data is added
                        command.Parameters.Add(new SqlParameter("username", user.Username));
                        command.Parameters.Add(new SqlParameter("password", user.Password));
                        command.Parameters.Add(new SqlParameter("firstname", user.Firstname));
                        command.Parameters.Add(new SqlParameter("lastname", user.Lastname));
                        command.Parameters.Add(new SqlParameter("email", user.Email));
                        command.Parameters.Add(new SqlParameter("phoneNumber", user.PhoneNumber));

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
        * Getting a user from the database with a certain username
        */
        public static UserModel getUserByUsername(string username)
        {
            UserModel user = new UserModel();
            using (SqlConnection con = new SqlConnection(DatabaseHelper.dbString)) // Using the right connection
            {
                con.Open();

                // Query
                using (SqlCommand command = new SqlCommand(                    
                    "SELECT * FROM " + DatabaseHelper.USER_TABLE + " WHERE username = @username", con))
                {
                    // Adding data to the query to get the right user
                    command.Parameters.Add(new SqlParameter("username", username));

                    SqlDataReader reader = command.ExecuteReader(); // Execute

                    // Getting data from result
                    while (reader.Read())
                    {
                        // Adding data from result to Usable StudentModel Object
                        user.Id = reader.GetInt16(0);
                        user.Username = reader.GetString(1);
                        user.Password = reader.GetString(2);
                        user.Email = reader.GetString(4);
                        user.PhoneNumber = reader.GetString(5);
                        user.Firstname = reader.GetString(6);
                        user.Lastname = reader.GetString(7);                      
                        

                        return user;
                    }
                }
            }
            return user;
        }

        /*
        * Getting a certain user according to an Id
        */
        public static UserModel getUserById(int id)
        {
            UserModel user = new UserModel();
            using (SqlConnection con = new SqlConnection(DatabaseHelper.dbString)) // Using right connection
            {
                con.Open();

                // Query
                using (SqlCommand command = new SqlCommand(
                    "SELECT * FROM" + DatabaseHelper.USER_TABLE + "WHERE id = @id", con))
                {
                    // Giving Id to search for
                    command.Parameters.Add(new SqlParameter("id", id));

                    SqlDataReader reader = command.ExecuteReader(); // Execute query

                    // Getting data from query
                    while (reader.Read())
                    {
                        // Adding data from results to new UserModel Object
                        user.Id = reader.GetInt16(0);
                        user.Username = reader.GetString(1);
                        user.Password = reader.GetString(2);
                        user.Email = reader.GetString(4);
                        user.PhoneNumber = reader.GetString(5);
                        user.Firstname = reader.GetString(6);
                        user.Lastname = reader.GetString(7);

                        return user;
                    }
                }
            }
            return user;
        }
    }
}
