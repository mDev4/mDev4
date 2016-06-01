using System;
using Shared.Database.Models;
using System.Collections.Generic;
using Shared.Database.Managers;
using Android.Widget;
using Android.App;
using Android.Views;

public class AnnouncementAdapter : BaseAdapter<AnnouncementModel>
{
    List<AnnouncementModel> items;
    Activity context;
    public AnnouncementAdapter(Activity context, IEnumerable<AnnouncementModel> items) : base() {
        this.context = context;
        this.items = (List<AnnouncementModel>)items;
    }
    public override long GetItemId(int position)
    {
        return position;
    }
    public override AnnouncementModel this[int position]
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
        view.FindViewById<TextView>(Android.Resource.Id.Text1).Text = items[position].Title;
        return view;
    }
}
