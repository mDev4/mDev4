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

namespace KVS_android
{
    [Activity(Label = "Registreer")]
    public class Register : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "register" layout resource
            SetContentView(Resource.Layout.Register);

            // Create your application here
            Button registerButton = FindViewById<Button>(Resource.Id.registerButton);

            EditText firstNameField = FindViewById<EditText>(Resource.Id.etFirstName);
            EditText lastNameField = FindViewById<EditText>(Resource.Id.etLastname);
            EditText userNameField = FindViewById<EditText>(Resource.Id.etUserName);
            EditText passwordField = FindViewById<EditText>(Resource.Id.etPass);
            EditText emailField = FindViewById<EditText>(Resource.Id.etEmail);
            EditText phoneField = FindViewById<EditText>(Resource.Id.etPhone);
            EditText sexField = FindViewById<EditText>(Resource.Id.etSex);

            registerButton.Click += delegate
            {
                UserModel user = new UserModel();
                user.Firstname = firstNameField.Text.ToString();
                user.Lastname = lastNameField.Text.ToString();
                user.Username = userNameField.Text.ToString();
                user.Password = passwordField.Text.ToString();
                user.Sex = sexField.Text.ToString();
                user.Email = emailField.Text.ToString();
                user.PhoneNumber = phoneField.Text.ToString();
                user.Clearance = 3;
                user.Active = true;

                // Check if all inputfields are filled in
                if (user.Firstname == String.Empty || user.Lastname == String.Empty || user.Username == String.Empty || user.Password == String.Empty || user.Email == String.Empty || user.PhoneNumber == String.Empty)
                {
                    Toast.MakeText(this, "Niet alle velden zijn ingevuld!", ToastLength.Long).Show();
                }
                else {
                    // User succesfully added
                    UserControl.addUser(user);
                    Toast.MakeText(this, "Gebruiker succesvol aangemaakt", ToastLength.Long).Show();
                    StartActivity(typeof(Login));
                }
                
            };
        }
       
    }
}