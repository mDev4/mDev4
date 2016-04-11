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

        public GroupModel(DateTime startYear, DateTime currCalendarYear, string name, int currYear)
        {
            this.startYear = startYear;
            this.currCalendarYear = currCalendarYear;
            this.name = name;
            this.currYear = currYear;
        }

        public GroupModel()
        {

        }


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
