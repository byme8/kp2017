using System.Linq;
using AutoMapper;
using kp.Business.Entities;
using kp.Business.Helpers;
using kp.Domain.Data;
using kp.Domain.Data.Core;
using kp.Entities.Data;
using Microsoft.AspNetCore.Builder;

namespace kp.Business.AutoMapper
{
    public static class AutoMapperConfigurator
    {
        public static void UseMapper(this IApplicationBuilder app)
        {
            Mapper.Initialize(mapper =>
            {
                mapper.CreateMap<UserEntity, User>().
                    ForMember(
                        domainUser => domainUser.Roles,
                        user => user.MapFrom(entity => entity.Roles.Select(o => o.Role)));
                mapper.CreateMap<User, UserEntity>().
                    ConvertUsing((domainEntity, entity) =>
                    {
                        entity = entity ?? new UserEntity();

                        entity.Id = domainEntity.Id;
                        entity.Login = domainEntity.Login;

                        if (!string.IsNullOrWhiteSpace(domainEntity.Password))
                        {
                            entity.PasswordHash = HashHelper.GetHash(domainEntity.Password);
                        }

                        return entity;
                    });

                mapper.CreateMap<RoleEntity, Role>();
                mapper.CreateMap<Role, RoleEntity>();

                mapper.MapToken();
                mapper.MapClient();
                mapper.SimpleMap<PaymentEntity, Payment>();
                mapper.SimpleMap<PaymentKindEntity, PaymentKind>();
            });

        }

        static void SimpleMap<TEntity, TDomainEntity>(this IMapperConfigurationExpression mapper)
            where TEntity : Entity
            where TDomainEntity : DomainEntity
        {
            mapper.CreateMap<TEntity, TDomainEntity>();
            mapper.CreateMap<TDomainEntity, TEntity>();
        }
    }
}