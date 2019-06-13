using System;
using System.Collections.Generic;
using System.Text;

namespace QuickReach.ECommerce
{
    public class InvalidFormatPasswordException : ApplicationException
    {
        public InvalidFormatPasswordException() : base()
        {
        }

        public InvalidFormatPasswordException(string description) : base(description)
        {
        }

    }
}
