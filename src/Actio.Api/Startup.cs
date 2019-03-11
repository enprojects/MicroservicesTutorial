using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Actio.Api.Core;

using Actio.Common.Commands;
using Actio.Common.Commands.ICommanInterfaces;
using Actio.Common.Handlers;
using Actio.Common.infrastructure.Extentions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Actio.Api
{
  
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public IServiceProvider _serviceProvider { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        { 
            services.AddMvc();
            services.AddBusManager(Configuration);
            services.AddHostedService<RegisterSubscriptions>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }

    }
}
