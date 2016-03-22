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
			Button button = FindViewById<Button>(Resource.Id.LogOut);

            button.Click += delegate {
                StartActivity(typeof(MainActivity));
            };
        }
    }
}