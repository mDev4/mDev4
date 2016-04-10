using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Database.Models
{
    class GroupModel
    {
        private DateTime startYear;
        private DateTime currCalendarYear;
        private string name;
        private int currYear;

        public DateTime StartYear
        {
            get
            {
                return startYear;
            }
            set
            {
                startYear = value;
            }
        }

        public DateTime CurrCalendarYear
        {
            get
            {
                return currCalendarYear;
            }
            set
            {
                currCalendarYear = value;
            }
        }

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }

        public int CurrYear
        {
            get
            {
                return currYear;
            }
            set
            {
                currYear = value;
            }
        }
    }
}
