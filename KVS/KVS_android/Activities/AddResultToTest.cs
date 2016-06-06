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
    [Activity(Label = "Voeg resultaat aan toets toe")]
    public class AddResultToTest : Activity
    {
        private TextView tvStudentName;
        private TextView tvTitle;
        private TextView tvDescription;
        private TextView tvDate;
        private EditText etGrade;
        private Button btnGrade;

        private StudentModel student;
        private TestModel test;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.AddResultToTest);

            //init
            tvStudentName = FindViewById<TextView>(Resource.Id.tvStudentName);
            tvTitle = FindViewById<TextView>(Resource.Id.tvTitle);
            tvDescription = FindViewById<TextView>(Resource.Id.tvDescription);
            tvDate = FindViewById<TextView>(Resource.Id.tvDate);
            etGrade = FindViewById<EditText>(Resource.Id.etGrade);
            btnGrade = FindViewById<Button>(Resource.Id.btnGrade);

            //get student and test
            string testId = Intent.GetStringExtra("testId");
            string studentId = Intent.GetStringExtra("studentId");

            student = StudentControl.getStudentById(studentId);
            test = TestControl.getTestById(testId);

            //fill in text fields
            tvStudentName.Text = student.Firstname + " " + student.Lastname;
            tvTitle.Text = test.Title;
            tvDescription.Text = test.Description;
            tvDate.Text = test.Date.ToString("dd-MM-yyyy");

            //get onclick event for button clicked
            btnGrade.Click += gradeButtonClick;

        }

        public void gradeButtonClick(object sender, EventArgs eventArgs)
        {
            string grade = etGrade.Text.ToString();
            TestStudentControl.addStudentToTest(student, test, grade);

            Intent intent = new Intent(this, typeof(Menu));
            StartActivity(intent);
            
        }
    }
}