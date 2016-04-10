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

    }
}
