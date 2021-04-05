using System;
using System.Threading.Tasks;
using WebApplication.Models;
using WebApplication.Services.Generic;
using WebApplication.Services.Product.Models;
using WebApplication.Services.UserSession.Models;

namespace WebApplication.Services.Product.Queries
{
    public class CustomerProductCatalogProductQueryProcessor : QueryProcessor<CustomerProductCatalogProductQuery, ProductBrowserViewModel>
    {
        public override Task<ProductBrowserViewModel> Handle(CustomerProductCatalogProductQuery query, CurrentUserSession currentUserSession)
        {
            // TODO
            return Task.FromResult(new ProductBrowserViewModel
            {
                ProductTree = new System.Collections.Generic.List<ProductBrowserCategoryViewModel>(),
            });
        }
    }
}
