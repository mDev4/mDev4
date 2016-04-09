using Shared.Database.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlConnection;
using System.Text;

namespace Shared.Database.Managers
{
    class UserControl
    {

        public static void addUser(UserModel user)
        {
            using (SqlConnection con = new SqlConnection(DatabaseHelper.dbString))
            {
                con.Open();

                try
                {
                    using (SqlCommand command = new SqlCommand(
                        "INSERT INTO [User] VALUES(@username, @password, @firstname, @lastname, @email, @phoneNumber)", con))
                    {
                        command.Parameters.Add(new SqlParameter("username", user.Username));
                        command.Parameters.Add(new SqlParameter("password", user.Password));
                        command.Parameters.Add(new SqlParameter("firstname", user.Firstname));
                        command.Parameters.Add(new SqlParameter("lastname", user.Lastname));
                        command.Parameters.Add(new SqlParameter("email", user.Email));
                        command.Parameters.Add(new SqlParameter("phoneNumber", user.PhoneNumber));
                        command.ExecuteNonQuery();
                    }
                }
                catch (SqlException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        public static UserModel getUserByUsername(string username)
        {
            UserModel user = new UserModel();
            using (SqlConnection con = new SqlConnection(DatabaseHelper.dbString))
            {
                con.Open();

                using (SqlCommand command = new SqlCommand(
                    "SELECT * FROM [User] WHERE username = @username", con))
                {
                    command.Parameters.Add(new SqlParameter("username", username));
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        user.Id = reader.GetInt32(0);
                        user.Username = reader.GetString(1);
                        user.Password = reader.GetString(2);
                        user.Firstname = reader.GetString(3);
                        user.Lastname = reader.GetString(4);
                        user.Email = reader.GetString(5);
                        user.PhoneNumber = reader.GetString(6);

                        return user;
                    }
                }
            }
            return user;
        }

        public static UserModel getUserById(int id)
        {
            UserModel user = new UserModel();
            using (SqlConnection con = new SqlConnection(DatabaseHelper.dbString))
            {
                con.Open();

                using (SqlCommand command = new SqlCommand(
                    "SELECT * FROM [User] WHERE username = @id", con))
                {
                    command.Parameters.Add(new SqlParameter("id", id));
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        user.Id = reader.GetInt32(0);
                        user.Username = reader.GetString(1);
                        user.Password = reader.GetString(2);
                        user.Firstname = reader.GetString(3);
                        user.Lastname = reader.GetString(4);
                        user.Email = reader.GetString(5);
                        user.PhoneNumber = reader.GetString(6);

                        return user;
                    }
                }
            }
            return user;
        }
    }
}
