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
						entity.Id = domainEntity.Id;
						entity.Login = domainEntity.Login;

						if (!string.IsNullOrWhiteSpace(domainEntity.Password))
						{
							entity.PasswordHash = GetHash(domainEntity.Password);
						}

						return entity;
					});

				mapper.CreateMap<RoleEntity, Role>();
				mapper.CreateMap<Role, RoleEntity>();
			});
		}

		private static string GetHash(string password)
		{
			using (var sha = SHA256.Create())
			{
				var passwordTextBytes = Encoding.UTF8.GetBytes(password);
				var hash = sha.ComputeHash(passwordTextBytes);
				var hashString = Encoding.ASCII.GetString(hash);
				return hashString;
			}
		}
	}
}
