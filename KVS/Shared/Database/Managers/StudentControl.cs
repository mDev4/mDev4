using System;
using System.Collections;
using System.Text;
using System.Data.SqlClient;
using Shared.Database.Models;


namespace Shared.Database.Managers
{
    class StudentControl
    {

        public static void addStudent(StudentModel student)
        {
            using (SqlConnection con = new SqlConnection(DatabaseHelper.dbString))
            {
                con.Open();
                DateTime date = new DateTime();
               
                try
                {
                    using (SqlCommand command = new SqlCommand(
                        "INSERT INTO [Student] VALUES(@firstName, @lastName, @studentCode, @birthDate, @particulars, @group)", con))
                    {
                        command.Parameters.Add(new SqlParameter("firstName", student.Firstname));
                        command.Parameters.Add(new SqlParameter("lastName", student.Lastname));
                        command.Parameters.Add(new SqlParameter("studentCode", student.Studentcode));
                        command.Parameters.Add(new SqlParameter("birthDate", student.BirthDate));
                        command.Parameters.Add(new SqlParameter("particulars", student.Particulars));
                        command.Parameters.Add(new SqlParameter("group", student.Group));
                        
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
