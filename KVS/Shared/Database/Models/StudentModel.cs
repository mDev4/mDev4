﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Database.Models
{
    class StudentModel
    {
        private int id;
        private string firstname;
        private string middlename;
        private string lastname;
        private string studentCode;
        private DateTime birthDate;
        private string particulars; //allergies etc
        private int startYear;
        private string sex;
        private bool alumni;

        public StudentModel(string firstname, string lastname)
        {
            this.firstname = firstname;
            this.lastname = lastname;
        }

        public StudentModel()
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

        public string Firstname
        {
            get
            {
                return firstname;
            }
            set
            {
                firstname = value;
            }
        }

        public string Middlename
        {
            get
            {
                return middlename;
            }
            set
            {
                middlename = value;
            }
        }

        public string Lastname
        {
            get
            {
                return lastname;
            }
            set
            {
                lastname = value;
            }
        }

        public string Studentcode
        {
            get
            {
                return studentCode;
            }
            set
            {
                studentCode = value;
            }
        }

        public DateTime BirthDate
        {
            get
            {
                return birthDate;
            }
            set
            {
                birthDate = value;
            }
        }

        public string Particulars
        {
            get
            {
                return particulars;
            }
            set
            {
                particulars = value;
            }
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

        public string Sex
        {
            get
            {
                return sex;
            }
            set
            {
                sex = value;
            }
        }

        public bool Alumni
        {
            get
            {
                return alumni;
            }
            set
            {
                alumni = value;
            }

        }
    }
}
