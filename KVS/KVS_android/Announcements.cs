using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace KVS_android
{
    [Activity(Label = "Announcements")]
    public class Announcements : ListActivity
    {
        // second try: ArrayList items = new ArrayList();
        // first try: string[] items;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "announcements" layout resource
            SetContentView(Resource.Layout.Announcements);

            // DOESN'T WORK!
            //items = new string[] { "Vegetables", "Fruits", "Flower Buds", "Legumes", "Bulbs", "Tubers" };
            //ListAdapter = new ArrayAdapter<String>(this, Resource.Layout.CustomRow, items);
        }
        
    // empty listview is called annList
    // custom listview where you can post announcement, description and maybe a picture
    // ann_image = image, ann_title = title of announcement, ann_descr = description of the announcement

    }
}