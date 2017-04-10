using kp.Entities.Exceptions;

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