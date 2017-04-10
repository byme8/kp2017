using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using kp.Business.AutoMapper;
using kp.Entities;
using kp.Entities.Exceptions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using kp.Business.Repositories;
using Microsoft.AspNetCore.Builder;
using kp.WebApi.Middleware;

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

            app.UseExceptionHandling();
            app.UseMvc();
			app.UseMapper();
            app.UseRepositoryInitializator();
        }
    }
}
