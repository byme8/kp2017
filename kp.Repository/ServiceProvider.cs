using System;
using System.Collections.Generic;
using System.Text;
using kp.Repository.Abstractions;
using kp.Repository.Repositories.Core;
using Microsoft.Extensions.DependencyInjection;

namespace kp.Repository
{
    public static class ServiceProvider
    {
		public static void AddRepositories(this IServiceCollection services)
		{
			services.AddSingleton(typeof(IRepository<>), typeof(Repository<>));
		}
    }
}
