// Copyright 2020 New Relic, Inc. All rights reserved.
// SPDX-License-Identifier: Apache-2.0


using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NewRelic.Agent.IntegrationTests.Shared;
using RabbitMQ.Client;

namespace RabbitMqCoreBasicMvcApplication
{
    public class Startup
	{
        private static readonly ConnectionFactory ChannelFactory = new ConnectionFactory() { HostName = RabbitMqConfiguration.RabbitMqServerIp };
        public static IModel Channel;

        public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddControllersWithViews();
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
            if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}
			else
			{
				app.UseExceptionHandler("/Home/Error");
			}
			app.UseStaticFiles();

			app.UseRouting();

			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllerRoute(
					name: "default",
					pattern: "{controller=Home}/{action=Index}/{id?}");
			});

            InitializeRabbitMqChannel();
        }

        private void InitializeRabbitMqChannel()
        {
            var connection = ChannelFactory.CreateConnection();
            Channel = connection.CreateModel();
        }
    }
}
