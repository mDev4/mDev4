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
using Newtonsoft.Json;
using Shared.Model;
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
            //TimeModel timer = new TimeModel();

            loginButton.Click += delegate
            {
                // If the EditText from the usernameField is empty, display toast message
                //if (usernameField.Text.Equals(""))
                // {
                //    Toast.MakeText(this, "Voer uw gebruikersnaam in", ToastLength.Long).Show();
                // }
                //else {
                // If text is not empty, get the user by username (the editted text from usernameField)
                //  UserModel user = UserControl.getUserByUsername(usernameField.Text.ToString());

                // If this username is correct...
                // if (user.Username == usernameField.Text.ToString())
                // {
                // If this password is correct, start Menu activity
                // if (user.Password == passwordField.Text.ToString())
               // {
                    // var timerSerialized = JsonConvert.SerializeObject(timer);
                    var intent = new Intent();
                    intent.SetClass(this, typeof(Menu));
                    //intent.PutExtra("TIMER",timerSerialized);
                    StartActivity(intent); //}
                        // If not correct or empty, display toast message
                        //else
                       // {
                            //Toast.MakeText(this, "Wachtwoord onjuist", ToastLength.Long).Show();
                      //  }
                  //  }
                    // If username is not correct, display toast message
                  //  else
                   // {
                       // Toast.MakeText(this, "Gebruikersnaam onjuist", ToastLength.Long).Show();
};
               }
            }
        }
    //}
//}