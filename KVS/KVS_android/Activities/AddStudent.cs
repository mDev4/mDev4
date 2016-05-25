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

namespace KVS_android
{
    [Activity(Label = "Voeg student toe")]
    public class AddStudent : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            base.SetTheme(Resource.Style.Base_V7_Theme_AppCompat);

            // Set our view from the "addStudent" layout resource
            SetContentView(Resource.Layout.AddStudent);

            // frameLayout setup
            var newFragment = new FragmentMainMenu();
            var ft = FragmentManager.BeginTransaction();
            ft.Add(Resource.Id.frameLayout1, newFragment);
            ft.Commit();

            // Initialize button and all the input fields
            Button addStudentButton2 = FindViewById<Button>(Resource.Id.addStudentButton2);

            EditText studentCodeField = FindViewById<EditText>(Resource.Id.etStudentCode);
            EditText firstNameField = FindViewById<EditText>(Resource.Id.etFirstName);
            EditText middleNameField = FindViewById<EditText>(Resource.Id.etMiddleName);
            EditText lastNameField = FindViewById<EditText>(Resource.Id.etLastName);
            EditText birthDateField = FindViewById<EditText>(Resource.Id.etBirthDate);
            EditText particularsField = FindViewById<EditText>(Resource.Id.etParticulars);
            EditText startYearField = FindViewById<EditText>(Resource.Id.etStartYear);
            EditText sexField = FindViewById<EditText>(Resource.Id.etSex);

            addStudentButton2.Click += delegate
            {
                StudentModel student = new StudentModel();
                student.Studentcode = studentCodeField.Text.ToString();
                student.Firstname = firstNameField.Text.ToString();
                student.Middlename = middleNameField.Text.ToString();
                student.Lastname = lastNameField.Text.ToString();
                student.BirthDate = DateTime.Parse(birthDateField.Text);    
                student.Particulars = particularsField.Text.ToString();
                student.StartYear = Int16.Parse(startYearField.Text);
                student.Sex = sexField.Text.ToString();

                // Check if all inputfields are filled in
                if (student.Studentcode == String.Empty || student.Firstname == String.Empty || student.Middlename == String.Empty || student.Lastname == String.Empty || student.BirthDate == null || student.Particulars == String.Empty || student.StartYear == null || student.Sex == String.Empty)
                {
                    Toast.MakeText(this, "Niet alle velden zijn ingevuld!", ToastLength.Long).Show();
                    Console.WriteLine("Niet alle velden zijn ingevuld error melding...");
                }
                else {
                    // User succesfully added
                    StudentControl.addStudent(student);
                    Toast.MakeText(this, "Student succesvol aangemaakt", ToastLength.Long).Show();
                    StartActivity(typeof(StudentsInGroup));
                }
            };
        }

    }
}