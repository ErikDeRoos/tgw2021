using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.Services.UserSession.Models;

namespace WebApplication.Services.UserSession
{
    public class ScopedUserSessionProvider
    {
        public CurrentUserSession GetCurrentSession()
        {
            // Use session store to fetch & store variable

            return new CurrentUserSession
            {
                Id = Guid.NewGuid(),
            };
        }
    }
}
