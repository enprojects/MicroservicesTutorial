using System;
using Actio.Common.Commands.ICommanInterfaces;

namespace Actio.Common.Commands
{
    public class CreateUser : ICommand
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }

    }
}