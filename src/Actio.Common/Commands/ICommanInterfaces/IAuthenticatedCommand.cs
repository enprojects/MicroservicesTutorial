using System;

namespace Actio.Common.Commands.ICommanInterfaces
{
    public interface IAuthenticatedCommand :ICommand
    {
         Guid UserId  {get; set;} 
    }
}