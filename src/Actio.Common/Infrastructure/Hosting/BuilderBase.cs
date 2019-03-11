using Actio.Common.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Actio.Common.infrastructure.Hosting
{
    public abstract class BuilderBase
    {
        public abstract ServiceHost Build();
    }
}
