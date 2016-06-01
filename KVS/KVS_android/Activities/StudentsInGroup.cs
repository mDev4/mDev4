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
using Android.Support.V7.App;
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
            base.SetTheme(Resource.Style.Base_V7_Theme_AppCompat);

            // Set our view from the "studentInGroup" layout resource
            SetContentView(Resource.Layout.StudentsInGroup);

            // frameLayout setup
            //var newFragment = new FragmentMainMenu();
            //var ft = FragmentManager.BeginTransaction();
            //ft.Add(Resource.Id.frameLayout1, newFragment);
            //ft.Commit();

            //AddStudent
            Button addStudentButton1 = FindViewById<Button>(Resource.Id.addStudentButton1);

            addStudentButton1.Click += delegate
            {
				Intent intent = new Intent(this, typeof(AddStudentToGroup));
				intent.PutExtra("groupId", this.Intent.GetStringExtra("groupId"));
                StartActivity(intent);
            };

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