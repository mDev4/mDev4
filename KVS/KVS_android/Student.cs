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


            // Set our view from the "menu" layout resource
            SetContentView(Resource.Layout.Student);

            // Create your application here
        }
    }
}