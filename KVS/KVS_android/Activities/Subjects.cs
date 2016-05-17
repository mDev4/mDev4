
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

namespace KVS_android
{
	[Activity (Label = "Subjects")]			
	public class Subjects : AppCompatActivity
	{
		protected override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);

			base.SetTheme (Resource.Style.Base_V7_Theme_AppCompat);
			// Set our view from the "menu" layout resource
			SetContentView(Resource.Layout.Subjects);

			var newFragment = new  FragmentMainMenu ();
			var ft = FragmentManager.BeginTransaction ();
			ft.Add (Resource.Id.frameLayoutSubjects, newFragment);
			ft.Commit ();

		}
	}
}

