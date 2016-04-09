using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace KVS_android
{
    [Activity(Label = "Menu")]
    public class Menu : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "menu" layout resource
            SetContentView(Resource.Layout.Menu);

            // Get our button from the layout resource,
            // and attach an event to it
            Button classButton = FindViewById<Button>(Resource.Id.classButton);
            Button logoutButton = FindViewById<Button>(Resource.Id.LogOut);
            Button rViewButton = FindViewById<Button>(Resource.Id.rInzien); 

            classButton.Click += delegate {
                StartActivity(typeof(Group));
            };

            logoutButton.Click += delegate {
                StartActivity(typeof(MainActivity));
            };

            rViewButton.Click += delegate
            {
                StartActivity(typeof(detailedResult));
            };


        }
    }
}