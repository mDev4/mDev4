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
            Button button = FindViewById<Button>(Resource.Id.registerButton);

            button.Click += delegate {
                StartActivity(typeof(Menu));
            };
        }
    }
}