using kp.Entities.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kp.Business.Exceptions
{
    public class TokenExpiredException : BusinessException
    {
        public TokenExpiredException() 
            : base("Token is expired")
        {
        }
    }
}
