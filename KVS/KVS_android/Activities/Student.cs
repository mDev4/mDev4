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
using KVS_android;

namespace KVS_android
{
    [Activity(Label = "Leerling")]
    public class Student : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "student" layout resource
            SetContentView(Resource.Layout.Student);

            // In dit scherm de naam van de student ophalen uit de listview en evt een foto van het kind
            // Hier ook de gegevens en bijzonderheden uit de database ophalen en weergeven
            // Ook edit functie toevoegen?
        }
    }
}