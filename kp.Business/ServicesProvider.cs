using System;
using System.Collections.Generic;
using System.Text;
using kp.Business.Abstractions;
using kp.Business.Services;
using Microsoft.Extensions.DependencyInjection;

namespace kp.Business
{
    public static class ServicesProvider
    {
		public static void AddBusiness(this IServiceCollection services)
		{
			services.AddSingleton<IUserService, UserService>();
		}
    }
}
