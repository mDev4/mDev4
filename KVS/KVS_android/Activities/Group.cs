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
    [Activity(Label = "Klas")]
    public class Group : ListActivity
    {
        private List<GroupModel> groups;
        private ListView groupsList;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "group" layout resource
            SetContentView(Resource.Layout.Group);

            //init
            groups = GroupControl.getAllGroups();
            groupsList = FindViewById<ListView>(Android.Resource.Id.List);




            GroupScreenAdapter adapter = new GroupScreenAdapter(this, groups);
            ListAdapter = adapter;

            adapter.NotifyDataSetChanged();

<<<<<<< develop
            groupsList.ItemClick += (sender, e) =>
            {
                GroupModel group = groups[e.Position];
                Console.WriteLine("Clicked " + group.Name);

                Intent intent = new Intent(this, typeof(StudentsInGroup));
                intent.PutExtra("groupId", group.Id);
                StartActivity(intent);
            };

            //spinner magicz
            Spinner spinner = FindViewById<Spinner>(Resource.Id.spinner);

            spinner.ItemSelected += new EventHandler<AdapterView.ItemSelectedEventArgs>(spinner_ItemSelected);
            var spinnerAdapter = ArrayAdapter.CreateFromResource(
                    this, Resource.Array.years_array, Android.Resource.Layout.SimpleSpinnerItem);

            spinnerAdapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            spinner.Adapter = spinnerAdapter;



        }

        private void spinner_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            Spinner spinner = (Spinner)sender;
=======
            //button1.Click += delegate {
            //  StartActivity(typeof(Student));
            //};

            var newFragment = new FragmentMainMenu();
            var ft = FragmentManager.BeginTransaction();
            ft.Add(Resource.Id.frameLayout2, newFragment);
            ft.Commit();

>>>>>>> Knoppen werkend

            string toast = string.Format("The planet is {0}", spinner.GetItemAtPosition(e.Position));
            Toast.MakeText(this, toast, ToastLength.Long).Show();
        }
    }
}
