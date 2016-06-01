
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
using KVS_android.Adapters;
using Shared.Database.Managers;

namespace KVS_android
{
	

	[Activity (Label = "AddStudentToGroup")]			
	public class AddStudentToGroup : ListActivity
	{
		private List<StudentModel> students;
		private ListView studentsList;
		private StudentAdapter studentAdapter;

		protected override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);
			SetContentView (Resource.Layout.addStudentToGroup);

			//var newFragment = new FragmentMainMenu();
			//var ft = FragmentManager.BeginTransaction();
			//ft.Add(Resource.Id.frameLayout1, newFragment);
			//ft.Commit();

			students = StudentControl.getAllStudents();
			var studentsList = FindViewById<ListView>(Android.Resource.Id.List);
			var studentAdapter = new StudentAdapter(this, students);
			studentsList.Adapter = studentAdapter;

			studentAdapter.NotifyDataSetChanged();

			studentsList.ItemClick += (sender, e) =>
			{
				//get clicked group
				StudentModel student = students[e.Position];
				Console.WriteLine("Clicked " + student.Firstname);
				GroupStudentControl.addStudentToGroup(student,Intent.GetStringExtra("groupId"));
			};
		}
	}
}

