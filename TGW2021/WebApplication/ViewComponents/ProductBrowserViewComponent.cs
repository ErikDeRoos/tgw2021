using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebApplication.Services.Generic;
using WebApplication.Services.Product.Models;
using WebApplication.Services.Product.Queries;
using WebApplication.Services.UserSession;

namespace WebApplication.ViewComponents
{
    public class ProductBrowserViewComponent : ViewComponent
    {
        private readonly HttpContext _context;
        private readonly ScopedUserSessionProvider _scopedUserSessionProvider;
        private readonly CustomerProductCatalogStartQueryProcessor _customerProductCatalogStartQueryProcessor;
        private readonly CustomerProductCatalogCategoryQueryProcessor _customerProductCatalogCategoryQueryProcessor;
        private readonly CustomerProductCatalogProductQueryProcessor _customerProductCatalogProductQueryProcessor;

        public ProductBrowserViewComponent(
            IHttpContextAccessor context,
            ScopedUserSessionProvider scopedUserSessionProvider,
            CustomerProductCatalogStartQueryProcessor customerProductCatalogStartQueryProcessor,
            CustomerProductCatalogCategoryQueryProcessor customerProductCatalogCategoryQueryProcessor,
            CustomerProductCatalogProductQueryProcessor customerProductCatalogProductQueryProcessor
            )
        {
            _context = context.HttpContext;
            _scopedUserSessionProvider = scopedUserSessionProvider;
            _customerProductCatalogStartQueryProcessor = customerProductCatalogStartQueryProcessor;
            _customerProductCatalogCategoryQueryProcessor = customerProductCatalogCategoryQueryProcessor;
            _customerProductCatalogProductQueryProcessor = customerProductCatalogProductQueryProcessor;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            _context.Request.RouteValues.TryGetValue("category", out dynamic currentProductCategoryViewing);
            _context.Request.RouteValues.TryGetValue("productId", out dynamic currentProductViewing);

            var currentUserSession = _scopedUserSessionProvider.GetCurrentSession();
            if (string.IsNullOrEmpty(currentProductCategoryViewing))
                return View(await _customerProductCatalogStartQueryProcessor.Handle(new CustomerProductCatalogStartQuery(), currentUserSession));
            if (string.IsNullOrEmpty(currentProductViewing))
                return View(await _customerProductCatalogCategoryQueryProcessor.Handle(new CustomerProductCatalogCategoryQuery { CategoryId = currentProductCategoryViewing }, currentUserSession));
            return View(await _customerProductCatalogProductQueryProcessor.Handle(new CustomerProductCatalogProductQuery { CategoryId = currentProductCategoryViewing, ProductId = currentProductViewing }, currentUserSession));
        }
    }
}
