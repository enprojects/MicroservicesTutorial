using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Actio.Common.Commands.ICommanInterfaces
{
   public interface ICommandHandler<T> where T: ICommand
    {
        Task HandleAsync(T command);
    }
}
 