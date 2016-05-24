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
using Android.Support.V7.App;
using Shared.Database.Models;
using Shared.Database.Managers;

namespace KVS_android
{
    [Activity(Label = "Klas")]
    public class Group : ListActivity
    {
        private List<GroupModel> groups;
        private ListView groupsList;
        private GroupScreenAdapter listAdapter;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            base.SetTheme(Resource.Style.Base_V7_Theme_AppCompat);

            // Set our view from the "group" layout resource
            SetContentView(Resource.Layout.Group);

            // frameLayout setup
            var newFragment = new FragmentMainMenu();
            var ft = FragmentManager.BeginTransaction();
            ft.Add(Resource.Id.frameLayout1, newFragment);
            ft.Commit();

            //AddGroup
            Button addGroupButton1 = FindViewById<Button>(Resource.Id.addGroupButton1);

            addGroupButton1.Click += delegate
            {
                StartActivity(typeof(AddGroup));
            };

            //spinner magicz
            Spinner spinner = FindViewById<Spinner>(Resource.Id.spinner);

            spinner.ItemSelected += new EventHandler<AdapterView.ItemSelectedEventArgs>(spinner_ItemSelected);
            var spinnerAdapter = ArrayAdapter.CreateFromResource(
                    this, Resource.Array.years_array, Android.Resource.Layout.SimpleSpinnerItem);

            spinnerAdapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            spinner.Adapter = spinnerAdapter;

            //init
            groups = GroupControl.getAllGroups();
            groupsList = FindViewById<ListView>(Android.Resource.Id.List);
            listAdapter = new GroupScreenAdapter(this, groups);
            groupsList.Adapter = listAdapter;

            listAdapter.NotifyDataSetChanged();

            groupsList.ItemClick += (sender, e) =>
            {
                //get clicked group
                GroupModel group = groups[e.Position];
                Console.WriteLine("Clicked " + group.Name);

                //go to overview of clicked group
                Intent intent = new Intent(this, typeof(StudentsInGroup));
                intent.PutExtra("groupId", group.Id.ToString());
                StartActivity(intent);
            };
        }

        //updates the listview of groups according to selected year in spinner
        private void spinner_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            //getting selected year from spinner
            Spinner spinner = (Spinner)sender;

            //button1.Click += delegate {
            //  StartActivity(typeof(Student));
            //};

            /*var newFragment = new FragmentMainMenu();
            var ft = FragmentManager.BeginTransaction();
            ft.Add(Resource.Id.frameLayout2, newFragment);
            ft.Commit();
            */

            string yearString = string.Format((string)spinner.GetItemAtPosition(e.Position));
            int year = Int32.Parse(yearString);

            //getting all groups by selected year
            groups = GroupControl.getGroupsByAcademicYear(year.ToString());

            //redefining adapter (workaround, using existing adapter somehow didn't work)
            listAdapter = new GroupScreenAdapter(this, groups);
            groupsList.Adapter = listAdapter;
            listAdapter.NotifyDataSetChanged();
        }


    }
}
