using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication.Data.DataModels.Product;

namespace WebApplication.Data.DataModels
{
    public interface IProductDataDomain
    {
        Task<List<Product.Category>> GetAllCategoriesAndProducts();

        Task<List<ProductCategoryProjection>> GetActiveProductsProjection();

        Task InsertNewActiveProductsProjection(List<ProductCategoryProjection> newData);
    }
}
