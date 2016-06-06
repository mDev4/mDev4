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
using Shared.Database.Models;
using Shared.Database.Managers;
using KVS_android.Adapters_and_Fragments;

namespace KVS_android
{
    [Activity(Label = "Voeg toets toe")]
    public class addTest : Activity
    {
        private EditText titleEt;
        private EditText descriptionEt;
        private Button addButton;
        private Button editDateButton;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.addTests);

            //init
            titleEt = FindViewById<EditText>(Resource.Id.etTitle);
            descriptionEt = FindViewById<EditText>(Resource.Id.etDescription);
            addButton = FindViewById<Button>(Resource.Id.addTestButton);
            editDateButton = FindViewById<Button>(Resource.Id.editDateButton);

            addButton.Click += addTestButtonClick;
            editDateButton.Click += dateSelectOnClick;
        }

        public void addTestButtonClick(object sender, EventArgs eventArgs)
        {
            TestModel test = new TestModel();
            test.Title = titleEt.Text.ToString();
            test.Description = descriptionEt.Text.ToString();
            test.Date = DateTime.Parse(editDateButton.Text.ToString());
            TestControl.addTest(test);
            this.Finish();
        }

        void dateSelectOnClick(object sender, EventArgs eventArgs)
        {

            DatePickerFragment frag = DatePickerFragment.NewInstance(delegate (DateTime time)
            {
                editDateButton.Text = time.Date.ToString("dd-MM-yyyy");

            });
            frag.Show(FragmentManager, DatePickerFragment.TAG);
        }
    }
}