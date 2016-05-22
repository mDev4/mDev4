using System;
using System.Collections.Generic;
using System.Text;
using Shared.Model;
using Android.OS;
using Android.Runtime;

namespace Shared.Model
{
    public class TimeModel
    {
        private readonly static double TIME_TO_LIVE = 5.000;
        public static DateTime timeLastClicked
        {
            get { return timeLastClicked; }
            set { setter(value); }
        }

        public TimeModel()
        {
            timeLastClicked = DateTime.Now;

        }

        public void checkTime() {
            timeLastClicked = DateTime.Now;
        }

        private static DateTime setter(DateTime model)
        {
            if (DateTime.Now.Subtract(timeLastClicked).Seconds > TIME_TO_LIVE)
            {
                throw new OutOfTimeException ("Connection has expired, please log in again");
            }
            else
            {
                return model;
            }
        }
    }
    }

