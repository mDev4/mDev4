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
    [Activity(Label = "Toetsen")]
    public class Tests : ListActivity
    {
        private List<TestModel> tests;
        private ListView testsList;
        private TestAdapter listAdapter;
        private Button editDateButton;
        private Button addTestsButton;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "group" layout resource
            SetContentView(Resource.Layout.Tests);

            addTestsButton = FindViewById<Button>(Resource.Id.addTestsButton);

            tests = TestControl.getAllTests();
            testsList = FindViewById<ListView>(Android.Resource.Id.List);
            listAdapter = new TestAdapter(this, tests);
            testsList.Adapter = listAdapter;

            listAdapter.NotifyDataSetChanged();

            //button logic
            editDateButton = FindViewById<Button>(Resource.Id.selectDateButton);
            editDateButton.Click += dateSelectOnClick;
            addTestsButton.Click += addTestButtonOnClick;

        }

        void dateSelectOnClick(object sender, EventArgs eventArgs) {
            
            DatePickerFragment frag = DatePickerFragment.NewInstance(delegate (DateTime time)
            {
                editDateButton.Text = time.Date.ToString("MM-dd-yyyy");
                tests = TestControl.getTestsByDate(editDateButton.Text);

                listAdapter = new TestAdapter(this, tests);
                testsList.Adapter = listAdapter;
                listAdapter.NotifyDataSetChanged();
            });
            frag.Show(FragmentManager, DatePickerFragment.TAG);
            }

       public void addTestButtonOnClick(object sender, EventArgs eventArgs)
        {
            Intent intent = new Intent(this, typeof(addTest));
            StartActivity(intent);
            
        }


        
    }
}
