using Actio.Common.Commands;
using Actio.Common.Commands.ICommanInterfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Actio.Common.Handlers
{


    public class CreateUserCommandHandler : ICommandHandler<CreateUser>
    { 

        public async Task HandleAsync(CreateUser command)
        {

            await Task.Run(() =>
            {
                var cmd = command;
            });
        }
    }
}
