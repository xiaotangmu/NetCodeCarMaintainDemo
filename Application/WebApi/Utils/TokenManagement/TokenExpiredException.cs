using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Utils.TokenManagement
{
    public class TokenExpiredException : Exception
    {
        public TokenExpiredException()
        {

        }

        public TokenExpiredException(string message) : base(message)
        {

        }
    }
}
