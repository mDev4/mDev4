using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Shared.Database.Models;
using System.Data.SqlClient;

namespace Shared.Database.Models
{
    public class AnnouncementModel
    {
        private int id;
        private string message;
        private int author;
        private string title;
        private string type;

        public AnnouncementModel(int id, string message, int author, string title, string type)
        {
            this.id = id;
            this.message = message;
            this.author = author;
            this.title = title;
            this.type = type;
        }

        public AnnouncementModel()
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

        public string Message
        {
            get
            {
                return message;
            }
            set
            {
                message = value;
            }
        }

        public int Author
        {
            get
            {
                return author;
            }
            set
            {
                author = value;
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

        public string Type
        {
            get
            {
                return type;
            }
            set
            {
                type = value;
            }
        }
    }
}
