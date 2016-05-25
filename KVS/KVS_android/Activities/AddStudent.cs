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
            
            /*
            registerButton.Click += delegate
            {
                UserModel user = new UserModel();
                user.Firstname = firstNameField.Text.ToString();
                user.Lastname = lastNameField.Text.ToString();
                user.Username = userNameField.Text.ToString();
                user.Password = passwordField.Text.ToString();
                user.Email = emailField.Text.ToString();
                user.PhoneNumber = phoneField.Text.ToString();

                // Check if all inputfields are filled in
                if (user.Firstname == String.Empty || user.Lastname == String.Empty || user.Username == String.Empty || user.Password == String.Empty || user.Email == String.Empty || user.PhoneNumber == String.Empty)
                {
                    Toast.MakeText(this, "Niet alle velden zijn ingevuld!", ToastLength.Long).Show();
                    Console.WriteLine("Niet alle velden zijn ingevuld error melding...");
                }
                else {
                    // User succesfully added
                    UserControl.addUser(user);
                    Toast.MakeText(this, "Gebruiker succesvol aangemaakt", ToastLength.Long).Show();
                    StartActivity(typeof(Login));
                }

            };
            */
        }

    }
}