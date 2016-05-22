using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Model
{
    class OutOfTimeException : Exception
    {
        public OutOfTimeException()
        {
        }

        public OutOfTimeException(String message):base(message){

        }


    }
}
