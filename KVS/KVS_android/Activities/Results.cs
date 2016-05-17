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
<<<<<<< HEAD

namespace KVS_android.Activities
{
    [Activity(Label = "Activity1")]
    public class Results : Activity
=======
using Android.Support.V7.App;

namespace KVS_android.Activities
{
    [Activity(Label = "Resultaten")]
    public class Results : AppCompatActivity
>>>>>>> develop
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            base.SetTheme(Resource.Style.Base_V7_Theme_AppCompat);
            SetContentView(Resource.Layout.insertResult);

            var newFragment = new FragmentMainMenu();
            var ft = FragmentManager.BeginTransaction();
<<<<<<< HEAD
            ft.Add(Resource.Id.frameLayout1, newFragment);
            ft.Commit();

            // Create your application here
=======
			ft.Add(Resource.Id.frameLayoutdetailedResult, newFragment);
            ft.Commit();

>>>>>>> develop
        }
    }
}