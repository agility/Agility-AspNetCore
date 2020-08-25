using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using Agility.Web;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.Extensions.Hosting;

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
            services.AddRazorPages().AddRazorRuntimeCompilation();

            // If using IIS:
            services.Configure<IISServerOptions>(options =>
            {
                options.AllowSynchronousIO = true;
            });

			AgilityContext.ConfigureServices(services, Configuration);

			// Build the intermediate service provider then return it
			return services.BuildServiceProvider();
		}

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
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

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            //configure the Agility Context 
            AgilityContext.Configure(app, env);

			app.UseStaticFiles();

            app.UseEndpoints(endpoints =>
            {
                //Agility Builtin Route
                endpoints.MapControllerRoute("Agility", "{*sitemapPath}", new { controller = "Agility", action = "RenderPage" },
           new { isAgilityPath = new Agility.Web.Mvc.AgilityRouteConstraint() });

                endpoints.MapControllerRoute(
           "default",
           "{controller=Home}/{action=Index}/{id?}");
            });

        }
	}
}
