using AutoMapper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication.Data.DataModels;
using WebApplication.Models;
using WebApplication.Services.Generic;
using WebApplication.Services.Product.Models;
using WebApplication.Services.UserSession.Models;
using System.Linq;
using WebApplication.Data.DataModels.Product;

namespace WebApplication.Services.Product.Queries
{
    public class CustomerProductCatalogStartQueryProcessor : QueryProcessor<CustomerProductCatalogStartQuery, ProductBrowserViewModel>
    {
        private readonly IMapper _mapper;
        private readonly IProductDataDomain _productDataDomain;

        public CustomerProductCatalogStartQueryProcessor(
            IMapper mapper,
            IProductDataDomain productDataDomain)
        {
            _mapper = mapper;
            _productDataDomain = productDataDomain;
        }

        public override async Task<ProductBrowserViewModel> Handle(CustomerProductCatalogStartQuery query, CurrentUserSession currentUserSession)
        {
            var data = await _productDataDomain.GetActiveProductsProjection();
            // Only return categories (could do this more efficient with a projected query, or a cache, or whatever)
            foreach(var category in data)
            {
                category.Products = null;
            }

            return new ProductBrowserViewModel
            {
                ProductTree = _mapper.Map<List<ProductBrowserCategoryViewModel>>(data),
            };
        }
    }
}
