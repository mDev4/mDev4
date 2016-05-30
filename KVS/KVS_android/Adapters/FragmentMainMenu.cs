using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using Android.Support.V4.Widget;
using Android.Support.Design.Widget;

using KVS_android;
using KVS_android.Activities;
using Android.Support.V7.App;

namespace KVS_android
{
    public class FragmentMainMenu : Fragment
    {
        public DrawerLayout drawerLayout { get; set; }
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            View view = inflater.Inflate(Resource.Layout.fragment_layout, container, false);
            drawerLayout = view.FindViewById<DrawerLayout>(Resource.Id.drawer_layout);
            NavigationView navigationView = view.FindViewById<NavigationView>(Resource.Id.nav_view);
            navigationView.NavigationItemSelected += NavigationView_NavigationItemSelected;
            TextView text = view.FindViewById<TextView>(Resource.Id.nameActivity);
            ActionBarDrawerToggle mDrawerToggle = new ActionBarDrawerToggle(
            Activity, drawerLayout, Resource.String.openDrawer, Resource.String.closeDrawer);
            return view;

        }

        void NavigationView_NavigationItemSelected(object sender, NavigationView.NavigationItemSelectedEventArgs e)
        {
            switch (e.MenuItem.ItemId)
            {
                case (Resource.Id.nav_menu):

                    if (this.Activity.GetType() != typeof(Menu))
                    {
                        var intent = new Intent(this.Activity, typeof(Menu));

                        StartActivity(intent);
                    }
                    break;
                case (Resource.Id.nav_ann):
                    if (this.Activity.GetType() != typeof(Menu))
                    {
                        var intent = new Intent(this.Activity, typeof(Menu));
                        StartActivity(intent);
                    }
                    break;
                case (Resource.Id.nav_klas):
                    if (this.Activity.GetType() != typeof(Group))
                    {
                        var intent = new Intent(this.Activity, typeof(Group));
                        StartActivity(intent);
                    }
                    break;
                case (Resource.Id.nav_results):
                    if (this.Activity.GetType() != typeof(Results))
                    {
                        var intent = new Intent(this.Activity, typeof(Results));
                        StartActivity(intent);
                    }
                    break;
            }

            // Close drawer
            drawerLayout.CloseDrawers();
        }


    }
}

