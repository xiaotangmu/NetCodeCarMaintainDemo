using System;
using System.Collections.Generic;
using System.Text;

namespace ViewModel.CustomException
{
    public class InfoException : Exception
    {
        public InfoException(string message) : base(message)
        {

        }
    }
}
