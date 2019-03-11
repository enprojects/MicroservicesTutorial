using Actio.Common.Commands.ICommanInterfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Actio.Common
{
    public sealed class Messages
    {
        private readonly IServiceProvider _provider;

        public Messages(IServiceProvider provider)
        {
            _provider = provider;
        }
    
        //public Task Dispatch(ICommand command)
        //{
        //    Type type = typeof(ICommandHandler<>);
        //    Type[] typeArgs = { command.GetType() };
        //    Type handlerType = type.MakeGenericType(typeArgs);

        //    dynamic handler = _provider.GetService(handlerType);
        //    Task result = handler.Handle((dynamic)command);

        //    return result;
        //}

        
    }
}
