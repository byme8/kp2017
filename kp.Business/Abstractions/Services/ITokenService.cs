using kp.Domain.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kp.Business.Abstractions.Services
{
    public interface ITokenService
    {
        Token Get(string login, string password);
        Token Get(Guid id);
        bool IsExpired(Guid id);
    }
}
