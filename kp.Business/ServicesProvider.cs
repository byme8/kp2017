using System;
using System.Collections.Generic;
using System.Text;
using kp.Entities.Abstractions;
using kp.Entities.Services;
using kp.Entities;
using kp.Entities.Context;
using Microsoft.Extensions.DependencyInjection;

namespace kp.Entities
{
    public static class ServicesProvider
    {
		public static void AddBusiness(this IServiceCollection services)
		{
			services.AddDbContext<kpContext>();
			services.AddScoped<IUserService, UserService>();
		}
    }
}
