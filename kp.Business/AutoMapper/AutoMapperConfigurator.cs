using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using kp.Business.Entities;
using kp.Domain.Data;
using kp.Entities.Data;
using Microsoft.AspNetCore.Builder;
using kp.Business.Helpers;

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
			});
		}

	}
}
