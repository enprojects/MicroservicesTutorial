using Actio.Common.RabbitMq;
using Actio.Common.Services;
using Microsoft.AspNetCore.Hosting;
using RawRabbit;
using System;
using System.Collections.Generic;
using System.Text;

namespace Actio.Common.infrastructure.Hosting
{
    public class HostBuilder : BuilderBase
    {
        private IWebHost _webHost;
        public HostBuilder(IWebHost webHost)
        {
            _webHost = webHost;
        }

        public override ServiceHost Build()
        {
            return new ServiceHost(_webHost);
        }
        
    }
}
