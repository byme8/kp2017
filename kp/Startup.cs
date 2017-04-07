using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using kp.Business.AutoMapper;
using kp.Entities;
using kp.Entities.Exceptions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using kp.Business.Repositories;

namespace kp
{
	public class Startup
	{
		public Startup(IHostingEnvironment env)
		{
			var builder = new ConfigurationBuilder()
				.SetBasePath(env.ContentRootPath)
				.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
				.AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
				.AddEnvironmentVariables();
			Configuration = builder.Build();
		}

		public IConfigurationRoot Configuration { get; }

		public void ConfigureServices(IServiceCollection services)
		{
			services.AddMvc();
			services.AddBusiness();
		}

		public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
		{
			loggerFactory.AddConsole(Configuration.GetSection("Logging"));
			loggerFactory.AddDebug();

			app.Use(async (context, next) =>
			{
				try
				{
					await next();
				}
				catch (BusinessException business)
				{
					var bytes = Encoding.UTF8.GetBytes($"\"{ business.Message }\"");
					context.Response.Body.Write(bytes, 0, bytes.Length);
				}
			});
			app.UseMvc();
			app.UseMapper();

            app.ApplicationServices.GetService<RepositoryInitializator>().TryInitialize();
        }
    }
}
