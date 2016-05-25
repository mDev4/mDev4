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
using Android.Support.V7.App;
using Shared.Database.Models;
using Shared.Database.Managers;

namespace KVS_android
{
    [Activity(Label = "Voeg groep toe")]
    public class AddGroup : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            base.SetTheme(Resource.Style.Base_V7_Theme_AppCompat);

            // Set our view from the "addGroup" layout resource
            SetContentView(Resource.Layout.AddGroup);

            // frameLayout setup
            var newFragment = new FragmentMainMenu();
            var ft = FragmentManager.BeginTransaction();
            ft.Add(Resource.Id.frameLayout1, newFragment);
            ft.Commit();

            // Create your application here
            Button addGroupButton2 = FindViewById<Button>(Resource.Id.addGroupButton2);

            EditText nameGroupField = FindViewById<EditText>(Resource.Id.etNameGroup);
            EditText currentAcademicYearField = FindViewById<EditText>(Resource.Id.etCurrentAcademicYear);
            EditText currentYearofStudyField = FindViewById<EditText>(Resource.Id.etCurrentYearofStudy);
            EditText startYearField = FindViewById<EditText>(Resource.Id.etStartYear);


            addGroupButton2.Click += delegate
            {
                GroupModel group = new GroupModel();
                group.Name = nameGroupField.Text.ToString();
                group.CurrCalendarYear = Int16.Parse(currentAcademicYearField.Text);
                group.CurrYear = Int16.Parse(currentYearofStudyField.Text);
                group.StartYear = Int16.Parse(startYearField.Text);
                
                // Check if all inputfields are filled in
                if (group.Name == String.Empty || group.CurrCalendarYear == null || group.CurrYear == null || group.StartYear == null)
                {
                    Toast.MakeText(this, "Niet alle velden zijn ingevuld!", ToastLength.Long).Show();
                    Console.WriteLine("Niet alle velden zijn ingevuld error melding...");
                }
                else {
                    // User succesfully added
                    GroupControl.addGroup(group);
                    Toast.MakeText(this, "Groep succesvol aangemaakt", ToastLength.Long).Show();
                    StartActivity(typeof(Group));
                }        
            };            
        }
    }
}