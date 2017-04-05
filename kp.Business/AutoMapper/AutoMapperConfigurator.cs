using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
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
				mapper.CreateMap<UserEntity, User>();
				mapper.CreateMap<User, UserEntity> ();
			});
		}
	}
}
