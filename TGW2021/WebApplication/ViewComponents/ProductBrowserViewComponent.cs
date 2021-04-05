using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebApplication.Services.Generic;
using WebApplication.Services.Product.Models;
using WebApplication.Services.Product.Queries;

namespace WebApplication.ViewComponents
{
    public class ProductBrowserViewComponent : ViewComponent
    {
        private readonly CustomerProductCatalogCategoryQueryProcessor _customerProductCatalogCategoryQueryProcessor;
        private readonly CustomerProductCatalogProductQueryProcessor _customerProductCatalogProductQueryProcessor;

        public ProductBrowserViewComponent(
            CustomerProductCatalogCategoryQueryProcessor customerProductCatalogCategoryQueryProcessor,
            CustomerProductCatalogProductQueryProcessor customerProductCatalogProductQueryProcessor
            )
        {
            _customerProductCatalogCategoryQueryProcessor = customerProductCatalogCategoryQueryProcessor;
            _customerProductCatalogProductQueryProcessor = customerProductCatalogProductQueryProcessor;
        }

        public async Task<IViewComponentResult> InvokeAsync(CurrentUserSession currentUserSession, string currentProductCategoryViewing, string currentProductViewing = null)
        {
            if (string.IsNullOrEmpty(currentProductViewing))
                return View(await _customerProductCatalogCategoryQueryProcessor.Handle(new CustomerProductCatalogCategoryQuery { CategoryId = currentProductCategoryViewing }, currentUserSession));
            return View(await _customerProductCatalogProductQueryProcessor.Handle(new CustomerProductCatalogProductQuery { CategoryId = currentProductCategoryViewing, ProductId = currentProductViewing }, currentUserSession));
        }
    }
}
