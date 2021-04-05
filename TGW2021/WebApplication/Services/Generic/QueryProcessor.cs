using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Services.Generic
{
    public abstract class QueryProcessor<T1, T2> : ICQRSProcessor where T1 : Query where T2 : class, new()
    {
        public abstract Task<T2> Handle(T1 query, CurrentUserSession currentUserSession);
    }
}
