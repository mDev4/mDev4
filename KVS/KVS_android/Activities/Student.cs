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
using KVS_android;
using Shared.Database.Models;
using Shared.Database.Managers;
using KVS_android.Activities;

namespace KVS_android
{
    [Activity(Label = "Leerling")]
    public class Student : Activity
    {

        private TextView nameTextView;
        private TextView particularsTextView;
        private TextView birthDateTextView;
        private TextView studentCodeTextView;
        private TextView sexTextView;
        private Button viewResults;
        private Button editResults;
        private StudentModel student;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            base.SetTheme(Resource.Style.Base_V7_Theme_AppCompat);

            // Set our view from the "student" layout resource
            SetContentView(Resource.Layout.Student);

            //init
            nameTextView = FindViewById<TextView>(Resource.Id.nameStudentTextField);
            particularsTextView = FindViewById<TextView>(Resource.Id.particularsTextField);
            birthDateTextView = FindViewById<TextView>(Resource.Id.birthDateTextField);
            sexTextView = FindViewById<TextView>(Resource.Id.sexTextField);
            studentCodeTextView = FindViewById<TextView>(Resource.Id.studentCodeTextField);
            viewResults = FindViewById<Button>(Resource.Id.resultsButton1);
            editResults = FindViewById<Button>(Resource.Id.resultsButton2);

            //get student to fill in value
            student = StudentControl.getStudentById(Intent.GetStringExtra("studentId"));

            //fill values into fields
            nameTextView.Text = student.Firstname + " " + student.Lastname;
            particularsTextView.Text += " " + student.Particulars;
            birthDateTextView.Text += " " + student.BirthDate.ToString("dd/MM/yyyy");
            studentCodeTextView.Text += " " + student.Studentcode;
            sexTextView.Text += " " + student.Sex;

            // frameLayout setup
            var newFragment = new FragmentMainMenu();
            var ft = FragmentManager.BeginTransaction();
            ft.Add(Resource.Id.frameLayout1, newFragment);
            ft.Commit();

            viewResults.Click += viewResultsOnClick;

            editResults.Click += editResultsOnClick;

        }

        public void viewResultsOnClick(object sender, EventArgs view)
        {
            Intent intent = new Intent(this, typeof(TestsPerStudents));
            intent.PutExtra("studentId", student.Id.ToString());
            StartActivity(intent);
        }

        public void editResultsOnClick(object sender, EventArgs view)
        {
            Intent intent = new Intent(this, typeof(AddStudentToTest));
            intent.PutExtra("studentId", student.Id.ToString());
            StartActivity(intent);
        }

    }
}