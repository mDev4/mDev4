using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Shared.Database.Managers;

namespace KVS_android
{
    [Activity(Label = "KVS App", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            Button registerButton = FindViewById<Button>(Resource.Id.btnRegister);

            registerButton.Click += delegate {
                StartActivity(typeof(Register));
            };

            Button loginButton = FindViewById<Button>(Resource.Id.btnLogin);

            loginButton.Click += delegate {
                StartActivity(typeof(Login));
            };

			

        }


    }
    
}

