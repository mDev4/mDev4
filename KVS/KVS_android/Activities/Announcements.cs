using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using KVS_android;
using Android.Support.V4.App;
using Android.Support.V7.App;

namespace KVS_android
{
    [Activity(Label = "Mededelingen")]
    public class Announcements : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            base.SetTheme(Resource.Style.Base_V7_Theme_AppCompat);

            // Set our view from the "Announcements" layout resource
            SetContentView(Resource.Layout.Announcements);

            // frameLayout setup
            var newFragment = new FragmentMainMenu();
            var ft = FragmentManager.BeginTransaction();
            ft.Add(Resource.Id.frameLayout1, newFragment);
            ft.Commit();
        }
    }
}