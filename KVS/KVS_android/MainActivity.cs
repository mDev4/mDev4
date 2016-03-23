using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

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

            Button button1 = FindViewById<Button>(Resource.Id.btnRegister);

            button1.Click += delegate {
                StartActivity(typeof(Register));
            };

            Button button2 = FindViewById<Button>(Resource.Id.btnLogin);

            button2.Click += delegate {
                StartActivity(typeof(Login));
            };

        }


    }
    
}

