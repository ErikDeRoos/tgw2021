using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Data.DataModels.Product
{
    public class ProductCategoryProjection
    {
        [Key]
        public string ProductCategoryId { get; set; }
        public string ProductCategoryDisplayName { get; set; }

        public ICollection<ProductProjection> Products { get; set; }
    }
}
