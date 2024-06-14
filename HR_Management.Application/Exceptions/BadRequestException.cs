using System;
using System.Collections.Generic;
using System.Text;

namespace HR_Management.Application.Exceptions
{
    public class BadRequestException : ApplicationException
    {
        public BadRequestException(string message):base(message) 
        {

        }
    }
}
