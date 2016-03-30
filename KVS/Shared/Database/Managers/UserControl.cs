using Shared.Database.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
                catch(SqlException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

    }
}
