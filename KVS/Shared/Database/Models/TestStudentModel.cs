using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Database.Models
{
    class TestStudentModel
    {
        private int student_id;
        private int test_id;
        private string grade;

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

        public int Test_id
        {
            get
            {
                return test_id;
            }
            set
            {
                test_id = value;
            }
        }

        public string Grade
        {
            get
            {
                return grade;
            }
            set
            {
                grade = value;
            }
        }
    }
}
