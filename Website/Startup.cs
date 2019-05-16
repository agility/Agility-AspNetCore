using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SpaServices.Webpack;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using Agility.Web;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.AspNetCore.Diagnostics;

namespace Website
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public IServiceProvider  ConfigureServices(IServiceCollection services)
		{

			services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();
			var assembly = typeof(Startup).GetTypeInfo().Assembly;

			services.AddMvc()
				.AddApplicationPart(assembly)
				.AddControllersAsServices();

			AgilityContext.ConfigureServices(services, Configuration);

			// Build the intermediate service provider then return it
			return services.BuildServiceProvider();
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IHostingEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
				app.UseBrowserLink();
			}
			else
			{
				app.UseExceptionHandler("/Home/Error");
			}

			app.UseExceptionHandler(appError =>
			{
				appError.Run(async context =>
				{
					var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
					if (contextFeature != null)
					{
						Agility.Web.Tracing.WebTrace.WriteException(contextFeature.Error);
					}
				});
			});

			//configure the Agility Context 
			Agility.Web.AgilityContext.Configure(app, env, useResponseCaching: true);

			app.UseStaticFiles();

			app.UseMvc(routes =>
			{
				//Agility Builtin Route
				routes.MapRoute("Agility", "{*sitemapPath}", new { controller = "Agility", action = "RenderPage" },
					new { isAgilityPath = new Agility.Web.Mvc.AgilityRouteConstraint() });

				routes.MapRoute(
					name: "default",
					template: "{controller=Home}/{action=Index}/{id?}");
			});

		}
	}
}
