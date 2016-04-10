using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Database.Models
{
    class GroupStudentModel
    {
        private DateTime group_currCalendarYear;
        private string group_name;
        private int student_id;

        public DateTime Group_currCalendarYear
        {
            get
            {
                return group_currCalendarYear;
            }
            set
            {
                group_currCalendarYear = value;
            }
        }
        public string Group_name
        {
            get
            {
                return group_name;
            }
            set
            {
                group_name = value;
            }
        }
        public int Student_id
        {
            get
            {
                return student_id;
            }
            set
            {
                student_id = value;
            }
        }
    }
}
