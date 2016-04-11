using System;
using System.Collections.Generic;
using Android.App;
using Android.Content;
using Android.Provider;
using Android.Views;
using Android.Widget;
using KVS_android;
using Shared.Database.Managers;
using Shared.Database.Models;
using Java.Lang;

public class ArrayAdapter: Android.Widget.BaseAdapter { 
	private System.Collections.Generic.List<Java.Lang.Object> list = new System.Collections.Generic.List<Java.Lang.Object>();
	private Activity baseContext;
	private Int32 layout;

	public ArrayAdapter(Int32 layout, Activity baseContext, List <Java.Lang.Object> list)
    {
		this.list = list;
        this.baseContext = baseContext;
		this.layout = layout;

    }

    public override int Count
    {
        get
        {
            return list.Count;
        }
    }

	public override Java.Lang.Object GetItem(int position)
    {
		return (Java.Lang.Object)list[position];
    }

    public override long GetItemId(int position)
    {
        return position;
    }

    public override View GetView(int position, View convertView, ViewGroup parent)
    {
		if (layout == 1) {
			return For_Subjects (convertView, parent);
		} else if (layout == 0) {
			return For_AddingResults (convertView, parent);
		} else if (layout == Resource.Layout.perStudent_Group) {
			return For_Student_Group (convertView, parent);
		} else {
			return null;
		}
    }

	public View For_Subjects(View convertView,ViewGroup parent){
		return convertView;
	}

	public View For_AddingResults(View convertView,ViewGroup parent){
		return convertView;
	}

	public View For_Student_Group(View convertView,ViewGroup parent){
		View view = convertView; // re-use an existing view, if one is supplied
		if (view == null) // otherwise create a new one
			view = baseContext.LayoutInflater.Inflate(layout,parent);
		StudentModel student = new StudentModel ("Henk", "Kast");
		list.Add (student);
		string textToShow = student.Firstname+" "+student.Lastname;
		TextView text = baseContext.FindViewById<TextView> (Resource.Id.text20);
		text.Text = textToShow;
		Intent intent = new Intent ();
		//intent.SetClass (baseContext,Student);
		text.Click += delegate {
			//baseContext.StartActivity(intent);
		};
		return convertView;
	}
		
}