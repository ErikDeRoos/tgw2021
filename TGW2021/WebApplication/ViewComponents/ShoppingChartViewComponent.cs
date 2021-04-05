using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebApplication.Services.Generic;
using WebApplication.Services.Order.Models;
using WebApplication.Services.Order.Queries;

namespace WebApplication.ViewComponents
{
    public class ShoppingChartViewComponent : ViewComponent
    {
        private readonly ShoppingChartContentQueryProcessor _shoppingChartContentQueryProcessor;

        public ShoppingChartViewComponent(
            ShoppingChartContentQueryProcessor shoppingChartContentQueryProcessor)
        {
            _shoppingChartContentQueryProcessor = shoppingChartContentQueryProcessor;
        }

        public async Task<IViewComponentResult> InvokeAsync(CurrentUserSession currentUserSession)
        {
            var chartContent = await _shoppingChartContentQueryProcessor.Handle(new ShoppingChartContentQuery(), currentUserSession);
            return View(chartContent);
        }
    }
}
