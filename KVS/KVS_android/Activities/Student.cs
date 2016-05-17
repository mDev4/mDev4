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
using KVS_android;
using Shared.Database.Models;
using Shared.Database.Managers;

namespace KVS_android
{
    [Activity(Label = "Leerling")]
    public class Student : Activity
    {

        private TextView nameTextView;
        private TextView particularsTextView;
        private TextView birthDateTextView;
        private TextView studentCodeTextView;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "student" layout resource
            SetContentView(Resource.Layout.Student);

            //init
            nameTextView = FindViewById<TextView>(Resource.Id.nameStudentTextField);
            particularsTextView = FindViewById<TextView>(Resource.Id.particularsTextField);
            birthDateTextView = FindViewById<TextView>(Resource.Id.birthDateTextField);
            studentCodeTextView = FindViewById<TextView>(Resource.Id.studentCodeTextField);

            //get student to fill in value
            StudentModel student = StudentControl.getStudentById(Intent.GetStringExtra("studentId"));

            //fill values into fields
            nameTextView.Text = student.Firstname + " " + student.Lastname;
            particularsTextView.Text += " " + student.Particulars;
            birthDateTextView.Text += " " + student.BirthDate.ToString("dd/MM/yyyy");
            studentCodeTextView.Text += " " + student.Studentcode;

        }
    }
}