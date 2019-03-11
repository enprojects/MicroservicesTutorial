using Actio.Common.Commands;
using Actio.Common.Commands.ICommanInterfaces;
using Actio.Common.infrastructure.RabbitMq.Extentions;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using RawRabbit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Actio.Common.RabbitMq
{
    public class BusManager

    {
        private readonly IServiceCollection _serviceCollection;
        private readonly IBusClient _bus;

        public BusManager(IServiceCollection serviceCollection, IBusClient bus)
        {
            _serviceCollection = serviceCollection;
            _bus = bus;
        }

        public  void SubscribeToCommand<TCommand>() where TCommand : ICommand
        { 
            var _serviceProvider = _serviceCollection.BuildServiceProvider();
            var handler = _serviceProvider.GetService<ICommandHandler<TCommand>>();
            _bus.WithCommandHandlerAsync(handler);
        }

        public void  PublishToBus<TCommand>(TCommand msg) where TCommand : ICommand
        {
            _bus.PublishToRabbit<TCommand>(msg);

        }

    }


}
