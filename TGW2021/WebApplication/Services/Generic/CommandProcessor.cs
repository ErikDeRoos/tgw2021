using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Services.Generic
{
    public abstract class CommandProcessor<T1, T2> : ICQRSProcessor where T1 : Command
    {
    }
}
