using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Data.DataModels.Product
{
    public class ProductCategoryProjection
    {
        public string ProductCategoryDisplayName { get; set; }
        public string ProductCategoryId { get; set; }
        public IEnumerable<ProductProjection> Products { get; set; }
    }
}
