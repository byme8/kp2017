using System;
using kp.Domain.Data;

namespace kp.Business.Abstractions.Services
{
    public interface ITokenService
    {
        Token Get(string login, string password);

        Token Get(Guid id);

        bool IsExpired(Guid id);
    }
}