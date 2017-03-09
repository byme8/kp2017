using System;
using System.Collections.Generic;
using System.Text;
using kp.Domain.Data;

namespace kp.Entities.Abstractions
{
    public interface IUserService
    {
		User Add(User user);
    }
}
