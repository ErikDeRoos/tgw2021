using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.Data.DataModels;
using WebApplication.Data.DataModels.Product;

namespace WebApplication.Data
{
    public class ApplicationDbContext : IdentityDbContext, ICustomerDataDomain, IOrderDataDomain, IProductDataDomain
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public async Task<IEnumerable<ProductCategoryProjection>> GetActiveProductsProjection()
        {
            var data = new[] {
                new ProductCategoryProjection {
                    ProductCategoryDisplayName = "Drinks",
                    ProductCategoryId = "drinks",
                    Products = Enumerable.Empty<ProductProjection>(),
                }
            };

            return data;
        }
    }
}
