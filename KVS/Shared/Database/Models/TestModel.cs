using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Database.Models
{
    public class TestModel
    {
         private int id;
         private string title;
         private DateTime date;
         private string description;

        public TestModel(int id, string title, DateTime date, string description)
        {
            this.id = id;
            this.title = title;
            this.date = date;
            this.description = description;
        }

        public TestModel()
        {
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

        public string Description
        {
            get
            {
                return description;
            }
            set
            {
                description = value;
            }
        }
    }
}
