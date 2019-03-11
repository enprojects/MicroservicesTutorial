using Actio.Common.Commands;
using Actio.Common.RabbitMq;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Actio.Api.Core
{
    public class RegisterSubscriptions :  IHostedService
    {
        private readonly BusManager _busMgr;

        public RegisterSubscriptions(BusManager busMgr)
        {
            _busMgr = busMgr;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            return Task.Run(() => {

                _busMgr.SubscribeToCommand<CreateUser>();

            });
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.FromResult(0);
        }
    }
}
