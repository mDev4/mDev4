﻿using System;
using Android.Views;
using Android.Widget;
using Android.App;
using Shared.Database.Models;
using System.Collections.Generic;
using Shared.Database.Managers;

public class GroupScreenAdapter : BaseAdapter<GroupModel>
{
    List<GroupModel> items;
    Activity context;
    public GroupScreenAdapter(Activity context, IEnumerable<GroupModel> items) : base() {
        this.context = context;
        this.items = (List<GroupModel>)items;
    }
    public override long GetItemId(int position)
    {
        return position;
    }
    public override GroupModel this[int position]
    {
        get { return items[position]; }
    }
    public override int Count
    {
        get { return items.Count; }
    }
    public override View GetView(int position, View convertView, ViewGroup parent)
    {
        View view = convertView; // re-use an existing view, if one is available
        if (view == null) // otherwise create a new one
            view = context.LayoutInflater.Inflate(Android.Resource.Layout.SimpleListItem1, null);
        view.FindViewById<TextView>(Android.Resource.Id.Text1).Text = items[position].Name;
        return view;
    }
}
