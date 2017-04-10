using System;
using System.Collections.Generic;

namespace kp.Entities.Exceptions
{
    public class BusinessException : ApplicationException
    {
        public BusinessException(string message)
            : base(message)
        {
            this.Messages = new[] { message };
        }

        public BusinessException(string[] messages)
            : base(string.Join("\n", messages))
        {
            this.Messages = messages;
        }

        public IEnumerable<string> Messages
        {
            get;
        }
    }
}