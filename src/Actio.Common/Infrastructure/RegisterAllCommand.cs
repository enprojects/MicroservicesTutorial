using Actio.Common.Commands.ICommanInterfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Actio.Common.Infrastructure
{
   public static  class RegisterAllCommand
    {


        public static void AddCommandHandler(this IServiceCollection services)
        {
           
            List<Type> handlerTypes = typeof(ICommand).Assembly.GetTypes().Where(x => x.GetInterfaces().Any(t => IsHandlerInterface(t))).ToList();
            
            foreach (Type type in handlerTypes)
            {
                AddHandler(services, type);
            }

        }


        private static void AddHandler(IServiceCollection services, Type type)
        {

            //var d1 = typeof(Task<>);
            //Type[] typeArgs = { typeof(Item) };
            //var makeme = d1.MakeGenericType(typeArgs);
            //object o = Activator.CreateInstance(makeme)

            Type interfaceType = type.GetInterfaces().Single(y => IsHandlerInterface(y));
            services.AddTransient(interfaceType, x =>
            {
                object obj = Activator.CreateInstance(type);


                return obj;
            });
        }

        private static bool IsHandlerInterface(Type type)
        {
            if (!type.IsGenericType)
                return false;

            Type typeDefinition = type.GetGenericTypeDefinition();

            return typeDefinition == typeof(ICommandHandler<>);
        }
    }
}
