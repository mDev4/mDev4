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
			Button rInsertButton = FindViewById<Button> (Resource.Id.rInvoeren);

            classButton.Click += delegate {
                StartActivity(typeof(Group));
            };
            Button annButton = FindViewById<Button>(Resource.Id.annButton);

            annButton.Click += delegate {
                //StartActivity(typeof(Announcements));
            };

            logoutButton = FindViewById<Button>(Resource.Id.LogOut);

            logoutButton.Click += delegate {
                StartActivity(typeof(MainActivity));
            };

            rViewButton.Click += delegate
            {
                //StartActivity(typeof());
            };

			rViewButton.Click += delegate
			{
				//StartActivity(typeof());
			};


        }
    }
}