using System;
using Android.Views;
using Java.Lang;
using KVS_android;

public class ArrayAdapter: Android.Widget.BaseAdapter { 
    private System.Collections.Generic.List<Java.Lang.Object> list = new System.Collections.Generic.List<Java.Lang.Object>();
    private View baseView;
	private Int32 layout;

	private ArrayAdapter(View view , Int32 layout)
    {
        baseView = view;
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
        return list[position];
    }

    public override long GetItemId(int position)
    {
        return position;
    }

    public override View GetView(int position, View convertView, ViewGroup parent)
    {
		if (layout == Resource.Layout._Listview_Subjects){
			For_Subjects (convertView,parent);
		}
		else if (layout == Resource.Layout.perItemDetailedResult){
			For_AddingResults (convertView,parent);
		}
		else if (layout == Resource.Layout.perStudent_Group){
			
		}
    }

	public View For_Subjects(View convertView,ViewGroup parent){
		
	}

	public View For_AddingResults(View convertView,ViewGroup parent){
	
	}

	public View For_Student_Group(View convertView,ViewGroup parent){
	}
		
}