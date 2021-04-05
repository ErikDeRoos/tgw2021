using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.Models;
using WebApplication.Services.Generic;
using WebApplication.Services.Order.Models;

namespace WebApplication.Services.Order.Queries
{
    public class ShoppingChartContentQueryProcessor : QueryProcessor<ShoppingChartContentQuery, ShoppingChartOverviewViewModel>
    {
        public override Task<ShoppingChartOverviewViewModel> Handle(ShoppingChartContentQuery query, CurrentUserSession currentUserSession)
        {
            // TODO for now
            return Task.FromResult(new ShoppingChartOverviewViewModel { ItemsCount = 1 });
        }
    }
}
