using System;
using System.Collections.Generic;
using System.Text;

namespace kp.Entities.Exceptions
{
	public class BusinessException : Exception
	{
		public BusinessException(string message) 
			: base(message)
		{
		}
	}
}
