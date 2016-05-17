using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Shared.Database.Models;
using Shared.Database.Managers;
using KVS_android.Adapters;

namespace KVS_android
{
    [Activity(Label = "StudentsInGroup")]
    public class StudentsInGroup : ListActivity
    {
        private List<StudentModel> students;
        private ListView studentsList;
        private StudentAdapter studentAdapter;

        protected override void OnCreate(Bundle savedInstanceState)
        { 
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.StudentsInGroup);

            //init

            Console.WriteLine("Group id from intent: "+ Intent.GetStringExtra("groupId"));
            students = GroupStudentControl.getStudentsByGroup(Intent.GetStringExtra("groupId"));
            studentsList = FindViewById<ListView>(Android.Resource.Id.List);
            studentAdapter = new StudentAdapter(this, students);
            studentsList.Adapter = studentAdapter;

            studentAdapter.NotifyDataSetChanged();

            studentsList.ItemClick += (sender, e) =>
            {
                //get clicked group
                StudentModel student = students[e.Position];
                Console.WriteLine("Clicked " + student.Firstname);

                //go to overview of clicked group
                Intent intent = new Intent(this, typeof(Student));
                intent.PutExtra("studentId", student.Id.ToString());
                StartActivity(intent);
            };
        }
    }
}