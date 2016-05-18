using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Database.Models
{
    class TestModel
    {
        private int id;
        private string title;
        private DateTime date;
        private string subject;

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

        public string Title
        {
            get
            {
                return title;
            }
            set
            {
                title = value;
            }
        }

        public DateTime Date
        {
            get
            {
                return date;
            }
            set
            {
                date = value;
            }
        }

        public string Subject
        {
            get
            {
                return subject;
            }
            set
            {
                subject = value;
            }
        }
    }
}
