using System;
using kp.Domain.Data;

namespace kp.Business.Abstractions.Services
{
    public interface IUserService : IEntityService<User>
    {
        User AddRole(Guid userId, Guid roleId);
        User RemoveRole(Guid userId, Guid roleId);

        bool IsAdmin(Guid userId);

        bool IsDatabaseAdmin(Guid id);
    }
}