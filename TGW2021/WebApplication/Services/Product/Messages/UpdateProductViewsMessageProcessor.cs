using System;
using System.Threading.Tasks;
using WebApplication.Data.DataModels;
using WebApplication.Services.Generic;
using WebApplication.Services.Product.Models;
using System.Linq;
using WebApplication.Data.DataModels.Product;

namespace WebApplication.Services.Product.Messages
{
    public class UpdateProductViewsMessageProcessor : MessageProcessor<UpdateProductViewsMessage>
    {
        private readonly IProductDataDomain _productDataDomain;

        public UpdateProductViewsMessageProcessor(IProductDataDomain productDataDomain)
        {
            _productDataDomain = productDataDomain;
        }

        public override async Task Handle(UpdateProductViewsMessage message)
        {
            var getAllProducts = await _productDataDomain.GetAllCategoriesAndProducts();

            var projectedList = getAllProducts
                .Select(c => new ProductCategoryProjection
                {
                    ProductCategoryId = c.Slug,
                    ProductCategoryDisplayName = c.DisplayName,
                    Products = c.Products
                        .Where(p => !p.Discontinued)
                        .Select(p => new ProductProjection
                        {
                            ProductId = p.Slug,
                            ProductDisplayName = p.DisplayName,
                            Description = p.Description,
                            Price = p.Price,
                            QuantityDescriptor = p.QuantityDescriptor,
                            QuantityPerPackage = p.QuantityPerPackage,
                            HasStock = true, // TODO merge with stock info from order domain
                        }).ToList(),
                })
                .Where(c => c.Products.Any())
                .ToList();

            await _productDataDomain.InsertNewActiveProductsProjection(projectedList);
        }
    }
}
