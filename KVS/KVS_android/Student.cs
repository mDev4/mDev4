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
    [Activity(Label = "Leerling")]
    public class Student : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // In dit scherm de naam van de student ophalen uit de listview en evt een foto van het kind
            // Hier ook de gegevens en bijzonderheden uit de database ophalen en weergeven
            // Ook edit functie toevoegen?

            // Set our view from the "menu" layout resource
            SetContentView(Resource.Layout.Student);

            // Create your application here
        }
    }
}