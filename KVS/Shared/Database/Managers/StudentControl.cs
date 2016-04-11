using System;
using System.Collections;
using System.Text;
using System.Data.SqlClient;
using Shared.Database.Models;
using System.Collections.Generic;

namespace Shared.Database.Managers
{
    class StudentControl
    {

        public static List<StudentModel> getStudentsByGroup(GroupModel group)
        {
            List<StudentModel> students = new List<StudentModel>();
            using (SqlConnection con = new SqlConnection(DatabaseHelper.dbString))
            {
                con.Open();

                using (SqlCommand command = new SqlCommand(
                    "SELECT * FROM [Student] WHERE group = @group", con))
                {
                    command.Parameters.Add(new SqlParameter("group", group.Name));

                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        StudentModel student = new StudentModel();
                        student.Id = reader.GetInt32(0);
                        student.Firstname = reader.GetString(1);
                        student.Lastname = reader.GetString(2);
                        student.Studentcode = reader.GetString(3);
                        student.BirthDate = reader.GetDateTime(4);
                        student.Particulars = reader.GetString(5);
                        student.Group = reader.GetString(6);

                        students.Add(student);
                    }
                }
            }
            return students;
        }

        

        public static void addStudent(StudentModel student)
        {
            using (SqlConnection con = new SqlConnection(DatabaseHelper.dbString))
            {
                con.Open();

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


        public static StudentModel getStudentByName(string firstName, string lastName)
        {
            StudentModel student = new StudentModel();
            using (SqlConnection con = new SqlConnection(DatabaseHelper.dbString))
            {
                con.Open();

                using (SqlCommand command = new SqlCommand(
                    "SELECT * FROM [Student] WHERE firstName = @firstName AND lastName = @lastName", con))
                {
                    command.Parameters.Add(new SqlParameter("firstName", firstName));
                    command.Parameters.Add(new SqlParameter("lastName", lastName));

                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        student.Id = reader.GetInt32(0);
                        student.Firstname = reader.GetString(1);
                        student.Lastname = reader.GetString(2);
                        student.Studentcode = reader.GetString(3);
                        student.BirthDate = reader.GetDateTime(4);
                        student.Particulars = reader.GetString(5);
                        student.Group = reader.GetString(6);

                        return student;
                    }
                }
            }
            return student;
        }

        public static StudentModel getStudentById(int id)
        {
            StudentModel student = new StudentModel();
            using (SqlConnection con = new SqlConnection(DatabaseHelper.dbString))
            {
                con.Open();

                using (SqlCommand command = new SqlCommand(
                    "SELECT * FROM [Student] WHERE Id = @id", con))
                {
                    command.Parameters.Add(new SqlParameter("id", id));

                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        student.Id = reader.GetInt32(0);
                        student.Firstname = reader.GetString(1);
                        student.Lastname = reader.GetString(2);
                        student.Studentcode = reader.GetString(3);
                        student.BirthDate = reader.GetDateTime(4);
                        student.Particulars = reader.GetString(5);
                        student.Group = reader.GetString(6);

                        return student;
                    }
                }
            }
            return student;
        }
    }
}
