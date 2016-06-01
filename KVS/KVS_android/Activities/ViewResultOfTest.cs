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

namespace KVS_android.Activities
{
    [Activity(Label = "ViewResultOfTest")]
    public class ViewResultOfTest : Activity
    {
        private TextView tvStudentName;
        private TextView tvTitle;
        private TextView tvDescription;
        private TextView tvDate;
        private TextView tvGrade;
       

        private StudentModel student;
        private TestModel test;
        private TestStudentModel result;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            base.SetTheme(Resource.Style.Base_V7_Theme_AppCompat);

            SetContentView(Resource.Layout.ViewResultOfTest);

            //init
            tvStudentName = FindViewById<TextView>(Resource.Id.tvStudentName);
            tvTitle = FindViewById<TextView>(Resource.Id.tvTitle);
            tvDescription = FindViewById<TextView>(Resource.Id.tvDescription);
            tvDate = FindViewById<TextView>(Resource.Id.tvDate);
            tvGrade = FindViewById<TextView>(Resource.Id.tvGrade);

            // frameLayout setup
            var newFragment = new FragmentMainMenu();
            var ft = FragmentManager.BeginTransaction();
            ft.Add(Resource.Id.frameLayout1, newFragment);
            ft.Commit();

            //get student and test
            string testId = Intent.GetStringExtra("testId");
            string studentId = Intent.GetStringExtra("studentId");

            student = StudentControl.getStudentById(studentId.ToString());
            test = TestControl.getTestById(testId.ToString());
            result = TestStudentControl.getResultById(student, test);


            //fill in text fields
            tvStudentName.Text = student.Firstname + " " + student.Lastname;
            tvTitle.Text = test.Title;
            tvDescription.Text = test.Description;
            tvDate.Text = test.Date.ToString("dd-MM-yyyy");
            tvGrade.Text = result.Grade;
        }
    }
}