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


namespace KVS_android
{
    [Activity(Label = "Tests")]
    public class Tests : ListActivity
    {
        private List<TestModel> tests;
        private ListView testsList;
        private TestAdapter listAdapter;
        private Button editDateButton;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "group" layout resource
            SetContentView(Resource.Layout.Tests);

            tests = TestControl.getAllTests();
            testsList = FindViewById<ListView>(Android.Resource.Id.List);
            listAdapter = new TestAdapter(this, tests);
            testsList.Adapter = listAdapter;

            listAdapter.NotifyDataSetChanged();

            //button logic
            editDateButton = FindViewById<Button>(Resource.Id.selectDateButton);
            editDateButton.Click += dateSelectOnClick;

        }

        void dateSelectOnClick(object sender, EventArgs eventArgs) {
            /**
            DatePickerFragment frag = DatePickerFragment.NewInstance(delegate (DateTime time)
            {
                editDateButton.Text = time.ToLongDateString();
            });
    */
            }


        
    }
}
