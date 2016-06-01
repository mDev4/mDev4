using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KVS_android;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Shared.Database.Models;
using Shared.Database.Managers;
using KVS_android.Adapters_and_Fragments;

namespace KVS_android
{
    [Activity(Label = "Mededelingen")]
    public class Announcements : ListActivity
    {
        private List<AnnouncementModel> ann;
        private ListView annList;
        private AnnouncementAdapter annAdapter;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            base.SetTheme(Resource.Style.Base_V7_Theme_AppCompat);

            // Set our view from the "Announcements" layout resource
            SetContentView(Resource.Layout.Announcements);

            ann = AnnouncementControl.getAllAnn();
            annList = FindViewById<ListView>(Android.Resource.Id.List);
            annAdapter = new AnnouncementAdapter(this, ann);
            annList.Adapter = annAdapter;

            annAdapter.NotifyDataSetChanged();

            // frameLayout setup
            var newFragment = new FragmentMainMenu();
            var ft = FragmentManager.BeginTransaction();
            ft.Add(Resource.Id.frameLayout1, newFragment);
            ft.Commit();
        }
    }
}