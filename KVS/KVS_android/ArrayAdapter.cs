using System;
using Android.Views;
using Java.Lang;

public class ArrayAdapter: Android.Widget.BaseAdapter { 
    private System.Collections.Generic.List<Java.Lang.Object> list = new System.Collections.Generic.List<Java.Lang.Object>();
    private View baseView;

    private ArrayAdapter(View view)
    {
     baseView = view;
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
        throw new NotImplementedException();
    }
}