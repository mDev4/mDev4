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
using Shared.Database.Managers;
using Shared.Database.Models;

namespace KVS_android
{
    [Activity(Label = "Login")]
    public class Login : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Login);

            // Get our button from the layout resource,
            // and attach an event to it
            Button loginButton = FindViewById<Button>(Resource.Id.loginButton);
            EditText usernameField = FindViewById<EditText>(Resource.Id.etUserName);
            EditText passwordField = FindViewById<EditText>(Resource.Id.etPass);

            loginButton.Click += delegate
            {
                if (!UserControl.getUserByUsername(usernameField.Text.ToString()).Equals(null))
                {
                    UserModel user = UserControl.getUserByUsername(usernameField.Text.ToString());
                    if (user.Password == passwordField.Text.ToString())
                    {
                        StartActivity(typeof(Menu));
                    }
                    else
                    {
                        Toast.MakeText(this, "Password was incorrect", ToastLength.Long).Show();
                    }

                }
                else
                {
                    Toast.MakeText(this, "User not found", ToastLength.Long).Show();
                }

            };
        }
    }
}