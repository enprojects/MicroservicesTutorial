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
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Actio.Common.Handlers;

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

        public void SubscribeToCommand<TCommand>() where TCommand : ICommand
        {
       
            var _serviceProvider = _serviceCollection.BuildServiceProvider();
            var handler = _serviceProvider.GetService<ICommandHandler<TCommand>>();
            _bus.WithCommandHandlerAsync(handler);
        }


        public void SubscribeToCommandSingle<TCommand>() where TCommand : ICommand
        {
            //good to know https://stackoverflow.com/questions/4963160/how-to-determine-if-a-type-implements-an-interface-with-c-sharp-reflection
            // This is for test purpose not in use 
            // Get Current type of command handler instance


            // getting all types from assembly
            var commandType = Assembly.GetExecutingAssembly()
                          .GetTypes()
                            .Where(t => CommnadTypePredicateExist<TCommand>(t)).First();


            var instance = Activator.CreateInstance(commandType);
             MethodInfo methodInfo = commandType.GetMethod("HandleAsync");
            methodInfo.Invoke(instance, new object [] { new CreateUser {  Email =""} }  );

        }


      

        private static bool CommnadTypePredicateExist<TCommand>(Type t)
        {
            //get the interface from each type 
            //if interfece is ICommandHandler<> with the same type as the Tcommand
            // return the type for instanse creation
            var allInterfaceForType = t.GetInterfaces();
              return  allInterfaceForType.Any(iType => IsHandlerInterface(iType, typeof(TCommand)));
          
        }


        private static bool IsHandlerInterface(Type interfaceType, Type type)
        {
            if (interfaceType.IsGenericType)
            {
                Type typeDefinition = interfaceType.GetGenericTypeDefinition();

                if (typeDefinition == typeof(ICommandHandler<>))
                {
                    return interfaceType.GetGenericArguments()[0].Name == type.Name;


                }
            }
            return false;
        }

        public void PublishToBus<TCommand>(TCommand msg) where TCommand : ICommand
        {
            _bus.PublishToRabbit<TCommand>(msg);

        }

    }


}
