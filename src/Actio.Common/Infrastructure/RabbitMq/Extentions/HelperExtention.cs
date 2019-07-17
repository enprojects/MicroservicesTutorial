using Actio.Common.Commands;
using Actio.Common.Commands.ICommanInterfaces;
using Actio.Common.Events;
using RabbitMQ.Client;
using RawRabbit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
 
namespace Actio.Common.infrastructure.RabbitMq.Extentions
{
   public static class HelperExtention
    {
     

        public static Task WithCommandHandlerAsync<TCommand>(this IBusClient bus, ICommandHandler<TCommand> handler) where TCommand : ICommand =>
            bus.SubscribeAsync<TCommand>(msg => handler.HandleAsync(msg));


        public static Task PublishToRabbit<TCommand>(this IBusClient bus, TCommand command) where TCommand : ICommand =>
            bus.PublishAsync<TCommand>(command);


        public static void SubscribeToCommand<TCommand>(this IBusClient bus, Func<ICommand, Task> handler) where TCommand : ICommand
        {
            bus.SubscribeAsync<TCommand>(msg => handler(msg));
        }


    }
}
