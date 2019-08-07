using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using ChrisNaborsWorks.Sevices;
using ChrisNaborsWorks.Models;
using Newtonsoft.Json.Serialization;
using Microsoft.AspNetCore.Identity;
using AutoMapper;
using ChrisNaborsWorks.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace ChrisNaborsWorks
{
    public class Startup
    {
		private IHostingEnvironment _hos;
		private IConfigurationRoot _config;
		public Startup(IHostingEnvironment hos)
		{
			_hos = hos;
			

			var builder = new ConfigurationBuilder()
				.SetBasePath(_hos.ContentRootPath)
				.AddJsonFile("config.json")
				.AddEnvironmentVariables();

			_config = builder.Build();

		}

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

			
			services.AddSingleton(_config);
			services.AddMvc(config =>
			{
				if (_hos.IsProduction())
				{
					config.Filters.Add(new RequireHttpsAttribute());
				}
			})
				.AddJsonOptions(op =>
				{
					op.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
				}
				);

			services.AddIdentity<ChrisNaborsWorksUser, IdentityRole>(config =>
			{
				config.User.RequireUniqueEmail = true;
				config.Password.RequiredLength = 8;
				//config.Password.RequireDigit = true;
			}
			  ).AddEntityFrameworkStores<DataContext>();

			services.ConfigureApplicationCookie (config =>
			{
				config.LoginPath = "/Auth/Login";
				config.Events = new Microsoft.AspNetCore.Authentication.Cookies.CookieAuthenticationEvents()
				{
					OnRedirectToLogin = async ctx =>
					{
						if (ctx.Request.Path.StartsWithSegments("/api") &&
						ctx.Response.StatusCode == 200)
						{
							ctx.Response.StatusCode = 401;
						}
						else
						{
							ctx.Response.Redirect(ctx.RedirectUri);
						}
						await Task.Yield();
					}
				};
			});
			services.AddAuthentication();
				//.AddFacebook(config =>
				//{
				//	config.AppId = _config["auth:facebook:appid"];
				//	config.AppSecret = _config["auth:facebook:appsecret"];
				//});

			services.AddEntityFrameworkSqlServer();
			services.AddScoped<IMailService, DebugMailService>();
			services.AddTransient<CNWorksSeedData>();
			services.AddDbContext<DataContext>();
			services.AddScoped<ICNWRepository, CNWRepository>();
			services.AddTransient<CryptoPriceService>();
			services.AddLogging();
		
		}

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory logger
			,CNWorksSeedData seeds, ILoggerFactory factory)
        {
			Mapper.Initialize(config =>
			{
				config.CreateMap<LikesViewModel, Likes>().ReverseMap();
				config.CreateMap<StoreViewModel, Store>().ReverseMap();
			});



			if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

			factory.AddDebug();

			app.UseStaticFiles();
			app.UseAuthentication();

			app.UseMvc(config =>
            {
				config.MapRoute(
					name: "Default",
					template: "{controller}/{action}/{id?}",
					defaults: new { Controller = "Home", action = "Index" });
            });
			seeds.ConfimSeedData().Wait();
        }

    }

	
}
