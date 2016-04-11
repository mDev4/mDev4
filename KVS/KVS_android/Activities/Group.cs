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

namespace KVS_android
{
    [Activity(Label = "Klas")]
    public class Group : ListActivity
    {
        private List<GroupModel> groups = new List<GroupModel>();
        private string[] groupNames;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "group" layout resource
            SetContentView(Resource.Layout.Group);

            // empty listview is called groupList
            // functions to click on one 1 item and get the information from the database

            // test button
			Button button1 = FindViewById<Button>(Resource.Id.button1);

            //add groups
            DateTime date = new DateTime(1997, 8, 23);
            GroupModel group = new GroupModel(date, date, "GROUP 1", 1);
            GroupModel group1 = new GroupModel(date, date, "GROUP 2", 2);

            groupNames = new String[2];
            groupNames[0] = group.Name;
            groupNames[1] = group1.Name;

            groups.Add(group);
            groups.Add(group1);
            
			ArrayAdapter adapter = new ArrayAdapter(this, Android.Resource.Layout.SimpleListItem1, groupNames);
			ListAdapter = adapter;
            
            adapter.NotifyDataSetChanged();

            //button1.Click += delegate {
              //  StartActivity(typeof(Student));
            //};


        }
    }
}