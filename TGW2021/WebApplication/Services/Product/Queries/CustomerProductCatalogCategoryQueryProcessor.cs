using System;
using System.Threading.Tasks;
using WebApplication.Models;
using WebApplication.Services.Generic;
using WebApplication.Services.Product.Models;
using WebApplication.Services.UserSession.Models;

namespace WebApplication.Services.Product.Queries
{
    public class CustomerProductCatalogCategoryQueryProcessor : QueryProcessor<CustomerProductCatalogCategoryQuery, ProductBrowserViewModel>
    {
        public override Task<ProductBrowserViewModel> Handle(CustomerProductCatalogCategoryQuery query, CurrentUserSession currentUserSession)
        {
            throw new NotImplementedException();
        }
    }
}
