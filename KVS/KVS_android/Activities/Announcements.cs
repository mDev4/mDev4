﻿
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
	[Activity (Label = "Announcements")]			
	public class Announcements : AppCompatActivity
	{
		protected override void OnCreate (Bundle savedInstanceState)
		{
			//base.OnCreate (savedInstanceState);
			//base.SetTheme (Resource.Style.Base_V7_Theme_AppCompat);
			//SetContentView(Resource.Layout.Announcements);

			//var newFragment = new  FragmentMainMenu ();
			//var ft = FragmentManager.BeginTransaction ();
			//ft.Add (Resource.Id.frameLayoutAnnouncements, newFragment);
			//ft.Commit ();
		}
	}
}

