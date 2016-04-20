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
using Shared.Database.Models;

namespace KVS_android.Adapters
{
    class StudentAdapter : BaseAdapter<StudentModel>
    {
        List<StudentModel> items;
        Activity context;
        public StudentAdapter(Activity context, IEnumerable<StudentModel> items) : base() {
            this.context = context;
            this.items = (List<StudentModel>)items;
        }
        public override long GetItemId(int position)
        {
            return position;
        }
        public override StudentModel this[int position]
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
            view.FindViewById<TextView>(Android.Resource.Id.Text1).Text = items[position].Firstname  + " " + items[position].Lastname;
            return view;
        }
    }
}