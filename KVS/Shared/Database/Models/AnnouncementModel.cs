using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Database.Models
{
    class AnnouncementModel
    {
        private string title;
        private string message;
        private string type;
        private UserModel userAdded;

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

        public UserModel UserAdded
        {
            get
            {
                return userAdded;
            }
            set
            {
                userAdded = value;
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
