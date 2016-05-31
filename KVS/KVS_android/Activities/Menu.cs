using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using KVS_android;
using Android.Support.V7.App;

using Android.Support.V4.Widget;

namespace KVS_android
{
    [Activity(Label = "Home")]
	public class Menu : AppCompatActivity
    {
        //TimeModel latestTimer;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            //latestTimer = JsonConvert.DeserializeObject<TimeModel>(base.Intent.GetStringExtra("TIMER"));
            base.OnCreate(savedInstanceState);
			base.SetTheme (Resource.Style.Base_Theme_AppCompat);
            // Set our view from the "menu" layout resource
            SetContentView(Resource.Layout.Menu);
            

			var newFragment = new FragmentMainMenu ();
			var ft = FragmentManager.BeginTransaction ();
			ft.Add (Resource.Id.frameLayout1, newFragment,"Drawer");
            ft.Commit();
            


        }
        /*public override bool DispatchTouchEvent(MotionEvent ev)
        {
            try
            {
                latestTimer.checkTime();
            }
            catch(OutOfTimeException e)
            {
                Toast.MakeText(this,e.Message,ToastLength.Long);
                StartActivity(typeof(Login));
            }
            return base.DispatchTouchEvent(ev);
       } **/
    }
}
