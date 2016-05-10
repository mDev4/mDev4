using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Database.Models
{
    public class GroupModel
    {
        private int id;
        private int startYear;
        private int currCalendarYear;
        private string name;
        private int currYear;

        public GroupModel(int startYear, int currCalendarYear, string name, int currYear)
        {
            this.startYear = startYear;
            this.currCalendarYear = currCalendarYear;
            this.name = name;
            this.currYear = currYear;
        }

        public GroupModel()
        {

        }


        public int StartYear
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

        public int CurrCalendarYear
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

        public int Id
        {
            get
            {
                return id;
            }
            set
            {
                id = value;
            }
        }

        public override string ToString()
        {
            return id.ToString();
        }
    }
}
