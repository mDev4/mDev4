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
            Button addGroupButton1 = FindViewById<Button>(Resource.Id.addGroupButton1);

            EditText nameGroupField = FindViewById<EditText>(Resource.Id.etNameGroup);
            EditText currentAcademicYearField = FindViewById<EditText>(Resource.Id.etCurrentAcademicYear);
            EditText currentYearofStudyField = FindViewById<EditText>(Resource.Id.etCurrentYearofStudy);
            EditText startYearField = FindViewById<EditText>(Resource.Id.etStartYear);

            /*
            addGroupButton.Click += delegate
            {
                GroupModel group = new GroupModel();
                group.Firstname = nameGroupField.Text.ToString();
                group.Lastname = currentAcademicYearField.Text.ToString();
                group.Username = currentYearofStudyField.Text.ToString();
                group.Password = startYearField.Text.ToString();

                // geen strings, maar ints ??

                
                // Check if all inputfields are filled in
                if (user.Firstname == String.Empty || user.Lastname == String.Empty || user.Username == String.Empty || user.Password == String.Empty || user.Email == String.Empty || user.PhoneNumber == String.Empty)
                {
                    Toast.MakeText(this, "Niet alle velden zijn ingevuld!", ToastLength.Long).Show();
                    Console.WriteLine("Niet alle velden zijn ingevuld error melding...");
                }
                else {
                    // User succesfully added
                    UserControl.addUser(user);
                    Toast.MakeText(this, "Gebruiker succesvol aangemaakt", ToastLength.Long).Show();
                    StartActivity(typeof(Login));
                }
                

            };
            */
        }
    }
}