using System;
using System.Collections.Generic;
using System.Text;
using Actio.Common.Commands.ICommanInterfaces;

namespace Actio.Common.Commands
{
    public interface AuthenticatedUser : ICommand
    {
         string Email { get; set; }
        string Password { get; set; }
    }
}
