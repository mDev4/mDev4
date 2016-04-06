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
    [Activity(Label = "Klas")]
    public class Group : ListActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "group" layout resource
            SetContentView(Resource.Layout.Group);

            // empty listview is called groupList
            // functions to click on one 1 item and get the information from the database

            // test button
            Button button1 = FindViewById<Button>(Resource.Id.button1);

            button1.Click += delegate {
                StartActivity(typeof(Student));
            };


        }
    }
}