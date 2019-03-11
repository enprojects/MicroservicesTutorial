using Actio.Common.Commands;
using Actio.Common.Infrastructure;
using Actio.Common.RabbitMq;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RawRabbit;
using RawRabbit.Configuration;
using RawRabbit.Instantiation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Actio.Common.infrastructure.Extentions
{
    public static class ServicesExtentions
    {
        public static void AddBusManager(this IServiceCollection services, IConfiguration configuration)
        {

            var options = new RawRabbitConfiguration();
            var section = configuration.GetSection("rabbitmq");

            section.Bind(options);
            var client = RawRabbitFactory.CreateSingleton(new RawRabbitOptions
            {
                ClientConfiguration = options
            });

            services.AddSingleton<IBusClient>(x => client);
            services.AddSingleton<BusManager>(x => new BusManager(services, x.GetService<IBusClient>()));
            services.AddCommandHandler();
        }

    }
}
