using Actio.Common.Commands;
using Actio.Common.Events;
using Actio.Common.infrastructure.Hosting;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using RawRabbit;
using System;
using System.Collections.Generic;
using System.Text;

namespace Actio.Common.Services
{
    public class ServiceHost : IServiceHost
    {

        private readonly IWebHost _webHost;

        public ServiceHost(IWebHost webHost)
        {
            _webHost = webHost;
        }

        public void Run() => _webHost.Run();
       


        public static HostBuilder Create<TStartup>(params string[] args) where TStartup : class
        {
            var config = new ConfigurationBuilder()
                                .AddEnvironmentVariables()
                                .AddCommandLine(args)
                                .Build();

            var webHostBuilder = WebHost.CreateDefaultBuilder(args)
                                        .UseConfiguration(config)
                                        .UseStartup<TStartup>();
             
            return new HostBuilder(webHostBuilder.Build());
        }


    }

    


}
