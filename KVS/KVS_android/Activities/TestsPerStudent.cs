using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KVS_android;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Shared.Database.Models;
using Shared.Database.Managers;
using KVS_android.Adapters_and_Fragments;
using KVS_android.Activities;

namespace KVS_android
{
    [Activity(Label = "Tests")]
    public class TestsPerStudents : ListActivity
    {
        private List<TestModel> tests;
        private ListView testsList;
        private TestAdapter listAdapter;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "TestsPerStudent" layout resource
            SetContentView(Resource.Layout.TestsPerStudent);

            tests = TestStudentControl.getTestsByStudent(StudentControl.getStudentById(Intent.GetStringExtra("studentId")));
            testsList = FindViewById<ListView>(Android.Resource.Id.List);
            listAdapter = new TestAdapter(this, tests);
            testsList.Adapter = listAdapter;

            listAdapter.NotifyDataSetChanged();

            testsList.ItemClick += (sender, e) =>
            {
                //get clicked group
                TestModel test = tests[e.Position];
                Console.WriteLine("Clicked " + test.Title);

                //go to overview of clicked test
                Intent intent = new Intent(this, typeof(ViewResultOfTest));
                intent.PutExtra("testId", test.Id.ToString());
                intent.PutExtra("studentId", StudentControl.getStudentById(Intent.GetStringExtra("studentId")).Id.ToString());
                StartActivity(intent);
            };

        }

    }


}

