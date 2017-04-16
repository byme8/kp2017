using System.Linq;
using AutoMapper;
using kp.Business.Abstractions.Repositories;
using kp.Business.Abstractions.Services;
using kp.Business.Abstractions.Validators;
using kp.Business.Entities;
using kp.Business.Services.Core;
using kp.Domain.Data;
using Microsoft.EntityFrameworkCore;

namespace kp.Business.Services
{
    public class ClientService : EntityService<Client, ClientEntity>, IEntityService<Client>
    {
        public ClientService(IRepository<ClientEntity> entities, INewEntryValidator<Client> newEntryValidator) 
            : base(entities, newEntryValidator)
        {
        }

        public override IQueryable<Client> Get()
        {
            return this.Repository.Get().
                Include(o => o.Payments).Select(o => Mapper.Map<Client>(o));
        }
    }
}
