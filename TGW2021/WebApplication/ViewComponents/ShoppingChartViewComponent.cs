using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebApplication.Services.Generic;
using WebApplication.Services.Order.Models;
using WebApplication.Services.Order.Queries;
using WebApplication.Services.UserSession;

namespace WebApplication.ViewComponents
{
    public class ShoppingChartViewComponent : ViewComponent
    {
        private readonly ScopedUserSessionProvider _scopedUserSessionProvider;
        private readonly ShoppingChartContentQueryProcessor _shoppingChartContentQueryProcessor;

        public ShoppingChartViewComponent(
            ScopedUserSessionProvider scopedUserSessionProvider,
            ShoppingChartContentQueryProcessor shoppingChartContentQueryProcessor)
        {
            _scopedUserSessionProvider = scopedUserSessionProvider;
            _shoppingChartContentQueryProcessor = shoppingChartContentQueryProcessor;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var currentUserSession = _scopedUserSessionProvider.GetCurrentSession();
            var chartContent = await _shoppingChartContentQueryProcessor.Handle(new ShoppingChartContentQuery(), currentUserSession);
            return View(chartContent);
        }
    }
}
